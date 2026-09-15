using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ImageMagick;

namespace LibMpvWrapper
{
    public class Overlay : IDisposable
    {
        private readonly object OverlayLock = new object();
        public bool IsDisposed { get; private set; }
        private readonly MpvPlayer Player;
        private readonly SortedList<int, OverlayMemory> Overlays = new SortedList<int, OverlayMemory>();

        public Overlay(MpvPlayer player)
        {
            this.Player = player;
        }

        public void RemoveOverlay(int layer)
        {
            if (Player.IsDisposed) throw new InvalidOperationException("Player is disposed");
            if (Overlays.TryGetValue(layer, out var memory))
            {
                Player.SendCommand(Player.STR_OVERLAY_REMOVE, layer.ToString());
                memory.Dispose();
            }
        }

        public void SetOverlayPicture(int layer, string file, int x, int y, int w, int h)
        {
            lock (OverlayLock)
            {
                if (!File.Exists(file)) throw new FileNotFoundException();

                if (Player.IsDisposed) throw new InvalidOperationException("Player is disposed");
                if (Overlays.TryGetValue(layer, out var memory))
                {
                    Player.SendCommand(Player.STR_OVERLAY_REMOVE, layer.ToString());
                    memory.Dispose();
                    Overlays.Remove(layer);
                }

                OverlayMemory overlayMemory;
                using (var image = new MagickImage(new FileInfo(file)))
                {
                    var pixels = image.GetPixels();
                    var rawPixelData = pixels.ToByteArray("BGRA");
                    if (rawPixelData == null)
                        throw new InvalidOperationException("No pixel data in image");
                    var rawPixelMemory = Marshal.AllocHGlobal(rawPixelData.Length);
                    Marshal.Copy(rawPixelData, 0, rawPixelMemory, rawPixelData.Length);
                    overlayMemory = new OverlayMemory(
                        layer, x, y, rawPixelMemory, "BGRA", (int)image.Width, (int)image.Height, w * 4, w, h);
                }

                Overlays.Add(layer, overlayMemory);
                Player.SendCommand(Player.STR_OVERLAY_ADD,
                    layer, overlayMemory.X, overlayMemory.Y, $"&{overlayMemory.Memory}", "BGRA",
                    overlayMemory.ImageWidth, overlayMemory.ImageHeight,
                    overlayMemory.Stride, overlayMemory.DisplayWidth, overlayMemory.DisplayHeight);
            }
        }

        public void Dispose()
        {
            lock (OverlayLock)
            {
                if (IsDisposed) return;
                IsDisposed = true;
                if (Player.IsDisposed)
                {
                    foreach (var overlayMemory in Overlays.Values)
                        overlayMemory.Dispose();
                    return;
                }
            }

            foreach (var overlayNumber in Overlays.Keys)
                RemoveOverlay(overlayNumber);
        }
    }
}