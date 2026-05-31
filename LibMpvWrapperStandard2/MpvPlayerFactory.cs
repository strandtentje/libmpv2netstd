using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.IO;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public class MpvPlayerFactory
    {
        public readonly mpv_handle Handle;
        private readonly object CreateLock = new object();
        public bool IsSpent { get; private set; }

        public MpvPlayerFactory()
        {
            this.Handle = mpv_initial.mpv_create();
        }

        public MpvPlayerFactory(FileInfo configFile)
        {
            if (!configFile.Exists)
                throw new FileNotFoundException();
            this.Handle = mpv_initial.mpv_create();
            string s = configFile.FullName;
            using (var config_file_ptr = s.ToMemory())
                mpv_options.
                    mpv_load_config_file(this.Handle, config_file_ptr.HGlobal).
                    Assert(configFile);
        }

        public MpvPlayer CreatePlayer(
            IntPtr parent,
            PlaylistLifecycle lifeCycle)
        {
            lock (CreateLock)
            {
                if (IsSpent)
                    throw new MpvPlayerFactorySpentException();
                IsSpent = true;
            }

            var keepOpen = lifeCycle.AsKeepOpenArg();

           // mpv_options.mpv_set_option_string(
             //   this.Handle, "keep-open", keepOpen);

            mpv_options.mpv_set_option_string(
                this.Handle, "idle", "yes");

            IntPtr pointer_to_parent = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(pointer_to_parent, parent);

            try
            {
                mpv_options.mpv_set_option(this.Handle, "wid", pointer_to_parent);
            }
            finally
            {
                Marshal.FreeHGlobal(pointer_to_parent);
            }

            mpv_initial.mpv_initialize(this.Handle).Assert();

            return new MpvPlayer(this.Handle);
        }
    }
}
