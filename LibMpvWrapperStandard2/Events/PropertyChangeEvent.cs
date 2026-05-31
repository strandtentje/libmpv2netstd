using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public delegate void PropertyChangeEventHandler(object sender,
        PropertyChangeEventArgs e);
    public class PropertyChangeEventArgs : EventArgs
    {
        public readonly string Name;        

        public PropertyChangeEventArgs(string name)
        {
            this.Name = name;
        }
    }
}
