using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace libmpv2netstd
{
    public static class mpv_platform
    {
        public static void Accomodate()
        {
            if (File.Exists("libmpv-2.so"))
                return;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (File.Exists("libmpv-2.dll"))
                    File.Copy("libmpv-2.dll", "libmpv-2.so");
                else
                {
                    Console.Error.WriteLine("Ensure libmpv-2.dll is next to the executable.");
                    Environment.Exit(-1);
                }
            }
            else
            {
                if (!File.Exists("libmpv-2.so") || !File.Exists("/usr/lib/libmpv-2.so"))
                {
                    Console.Error.WriteLine(
                        "Ensure libmpv2 is installed, located next to these binaries, or configure symlinks to have it at /usr/lib/libmpv-2.so");
                }
            }
        }
    }
}
