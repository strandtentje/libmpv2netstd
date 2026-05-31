using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mpvtest
{
    public static class WindowPosExtensions
    {
        public static void PersistPosition(this Form form)
        {
            var file = string.Format("{0}.pos.txt", form.GetType().Name);
            if (File.Exists(file))
            {
                var posLines = File.ReadAllLines(file);
                if (posLines.Length > 1)
                {
                    if (int.TryParse(posLines[0], out int xFile) &&
                        int.TryParse(posLines[1], out int yFile))
                    {
                        form.Location = new Point(xFile, yFile);
                    }
                }
                if (posLines.Length > 3)
                {
                    if (int.TryParse(posLines[2], out int wFile) &&
                        int.TryParse(posLines[3], out int hFile))
                    {
                        form.Size = new Size(wFile, hFile);
                    }
                }
            }

            var locationGraceEwh = new EventWaitHandle(false, EventResetMode.ManualReset);

            var saveWorker = new System.Threading.Timer(new TimerCallback(__ =>
            {
                Debug.WriteLine("saving pos");

                var location = (Point)form.Invoke(new Func<object, object>(_ => { return form.Location; }), new object[] { null });
                var size = (Size)form.Invoke(new Func<object, object>(_ => { return form.Size; }), new object[] { null });

                File.WriteAllLines(file, new string[]
                {
                    location.X.ToString("00000", CultureInfo.InvariantCulture),
                    location.Y.ToString("00000", CultureInfo.InvariantCulture),
                    size.Width.ToString("00000", CultureInfo.InvariantCulture),
                    size.Height.ToString("00000", CultureInfo.InvariantCulture)
                });
            }), null, Timeout.Infinite, Timeout.Infinite);
            
            void HandleLocationSizeChange(object sender, EventArgs e)
            {
                saveWorker.Change(Timeout.Infinite, Timeout.Infinite);
                saveWorker.Change(1000, Timeout.Infinite);
            }

            form.LocationChanged += HandleLocationSizeChange;
            form.SizeChanged += HandleLocationSizeChange;

            void HandleFormOut(object sender, EventArgs e)
            {
                saveWorker.Dispose();
                locationGraceEwh.Dispose();
            }

            form.FormClosing += HandleFormOut;
        }
    }
}
