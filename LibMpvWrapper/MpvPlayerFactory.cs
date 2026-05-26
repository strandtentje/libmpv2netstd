using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.IO;

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
            mpv_options.
                mpv_load_config_file(this.Handle, ref s).
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

            mpv_options.
                mpv_set_option(this.Handle, mpv_option_name.KeepOpen,
                mpv_format.String, ref keepOpen).Assert("keep-open", keepOpen);

            string s = "yes";
            mpv_options.
                mpv_set_option(this.Handle, mpv_option_name.Idle,
                mpv_format.String, ref s).Assert("idle", "yes");

            var longParent = parent.ToInt64();

            mpv_options.
                mpv_set_option(this.Handle, mpv_option_name.ParentWindowID,
                mpv_format.Long, ref longParent).Assert("wid", longParent);

            mpv_initial.mpv_initialize(this.Handle).Assert();

            return new MpvPlayer(this.Handle);
        }
    }
}
