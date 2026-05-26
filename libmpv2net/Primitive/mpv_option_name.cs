using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_option_name
    {
        public mpv_option_name(string name)
        {
            this.name = name;
        }

        [MarshalAs(UnmanagedType.LPStr)]
        public string name;

        public static mpv_option_name 
            ParentWindowID = new mpv_option_name("wid"),
            KeepOpen = new mpv_option_name("keep-open"),
            Idle = new mpv_option_name("idle");
    }
}
