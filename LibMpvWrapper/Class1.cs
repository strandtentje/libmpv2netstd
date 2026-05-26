using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.IO;

namespace LibMpvWrapper
{
    public class Mpv : IDisposable
    {
        public readonly mpv_handle Handle;

        public Mpv()
        {
            this.Handle = mpv_initial.mpv_create();
        }

        public Mpv(FileInfo configFile)
        {
            if (!configFile.Exists)
                throw new FileNotFoundException();
            this.Handle = mpv_initial.mpv_create();
            mpv_options.
                mpv_load_config_file(this.Handle, configFile.FullName).
                ThrowOnFail(MpvOrigin.LoadConfig(configFile.FullName));
        }

        public MpvPlayer CreatePlayer(IntPtr parent, Lifecycle lifeCycle)
        {
            var longParent = parent.ToInt64();

            mpv_options.
                mpv_set_option(this.Handle, mpv_option_name.ParentWindowID,
                mpv_format.Long, longParent).Assert("wid", longParent);

            var keepOpen = lifeCycle.AsKeepOpenArg();

            mpv_options.
                mpv_set_option(this.Handle, mpv_option_name.KeepOpen,
                mpv_format.String, keepOpen).ThrowOnFail(
                MpvOrigin.SetOption("keep-open", keepOpen));

            mpv_initial.mpv_initialize(this.Handle).Assert();
        }

        public void Dispose()
        {
            mpv_initial.mpv_terminate_destroy(this.Handle);
        }       
    }
}
