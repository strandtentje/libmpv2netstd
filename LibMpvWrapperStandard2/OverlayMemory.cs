using System;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public class OverlayMemory : IDisposable
    {
        public readonly IntPtr Memory;
        public readonly string Format;
        public readonly int Layer, X, Y, DisplayWidth, DisplayHeight;
        public readonly int ImageWidth, ImageHeight, Stride;

        public OverlayMemory(int layer, int x, int y, IntPtr memory, string format, int imageWidth, int imageHeight,
            int stride, int displayWidth, int displayHeight)
        {
            Layer = layer;
            X = x;
            Y = y;
            Memory = memory;
            Format = format;
            ImageWidth = imageWidth;
            ImageHeight = imageHeight;
            Stride = stride;
            DisplayWidth = displayWidth;
            DisplayHeight = displayHeight;
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Memory);
        }
    }
}