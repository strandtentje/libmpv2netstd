using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (!Directory.Exists("/usr/lib"))
                {
                    Console.Error.WriteLine("Missing /usr/lib");
                    Environment.Exit(-1);
                }

                var libMpvs = new List<FileInfo>();
                (new DirectoryInfo("/usr/lib")).RecursiveFind("libmpv*", libMpvs);
                var latestLibMpv = libMpvs.OrderBy(x => x.CreationTime).Last();
                var assemblyDirectory = Path.GetDirectoryName(typeof(mpv_platform).Assembly.Location);
                if (assemblyDirectory == null)
                {
                    Console.Error.WriteLine("Cannot locate assembly working directory");
                    Environment.Exit(-1);
                }

                var targetFile = Path.Combine(assemblyDirectory, "libmpv-2.so");
                latestLibMpv.CopyTo(targetFile);
            }
            else
            {
                Console.Error.WriteLine("This OS doesn't seem to be supported");
                Environment.Exit(-1);
            }
        }
    }

    public static class FileIOExtensions
    {
        public static void RecursiveFind(this DirectoryInfo info, string pattern, List<FileInfo> target)
        {
            try
            {
                target.AddRange(info.GetFiles(pattern, SearchOption.TopDirectoryOnly));
            }
            catch (Exception)
            {
                // whatever
            }

            try
            {
                var dirs = info.GetDirectories();
                foreach (var dir in dirs)
                {
                    dir.RecursiveFind(pattern, target);
                }
            }
            catch (Exception)
            {
                // whatever
            }
        }
    }
}