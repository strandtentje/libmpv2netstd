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
        public readonly object RawData;

        public PropertyChangeEventArgs(string name, object data)
        {
            this.Name = name;
            this.RawData = data;
        }

        public bool IsNull
        {
            get
            {
                return RawData == null;
            }
        }

        public string AsString
        {
            get
            {
                return RawData as string;
            }
        }

        public bool IsBool
        {
            get
            {
                return RawData is bool;
            }
        }

        public bool AsBool
        {
            get
            {
                if (RawData is bool)
                    return (bool)RawData;
                else
                    return false;
            }
        }

        public bool IsLong
        {
            get
            {
                return RawData is long;
            }
        }

        public long AsLong
        {
            get
            {
                if (RawData is long)
                    return (long)RawData;
                else
                    return 0L;
            }
        }

        public bool IsDouble
        {
            get
            {
                return RawData is double;
            }
        }

        public double AsDouble
        {
            get
            {
                if (RawData is double)
                    return (double)RawData;
                else
                    return 0.0;
            }
        }

        public object[] AsArray
        {
            get
            {
                return RawData as object[];
            }
        }

        public Dictionary<string, object> AsDictionary
        {
            get
            {
                return RawData as Dictionary<string, object>;
            }
        }

        public byte[] AsBytes
        {
            get
            {
                return RawData as byte[];
            }
        }

        public static PropertyChangeEventArgs From(mpv_event evt)
        {
            if (evt.event_id != mpv_event_id.PropertyChange)
                throw new ArgumentException("may only use this for prop chg.");
            var propChg = (mpv_event_property)Marshal.PtrToStructure(
                evt.data, typeof(mpv_event_property));
            var data = propChg.data.ToObject(propChg.format);
            return new PropertyChangeEventArgs(propChg.name, data);
        }
    }
}
