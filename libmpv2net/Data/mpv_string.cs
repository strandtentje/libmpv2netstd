using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;

namespace libmpv2net
{
    /// <summary>
    /// Normally equivalent to directly expressing a string marshalled
    /// as lpstr, but useful for string arrays.
    /// </summary>
    public struct mpv_string
    {
        [MarshalAs(UnmanagedType.LPUTF8Str)]
        public string value;

        public static mpv_string[] Create(params object[] args)
        {
            var arr = new mpv_string[args.Length + 1];
            arr[args.Length] = new mpv_string()
            {
                value = null
            };
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is string)
                {
                    arr[i] = new mpv_string()
                    {
                        value = (string)args[i],
                    };
                }
                else if (args[i] is int)
                {
                    arr[i] = new mpv_string()
                    {
                        value = ((int)args[i]).ToString(CultureInfo.InvariantCulture),
                    };
                }
                else if (args[i] is decimal)
                {
                    arr[i] = new mpv_string()
                    {
                        value = ((decimal)args[i]).
                        ToString(CultureInfo.InvariantCulture),
                    };
                }
                else if (args[i] is double)
                {
                    arr[i] = new mpv_string()
                    {
                        value = ((double)args[i]).
                        ToString(CultureInfo.InvariantCulture),
                    };
                }
                else if (args[i] is long)
                {
                    arr[i] = new mpv_string()
                    {
                        value = ((long)args[i]).
                        ToString(CultureInfo.InvariantCulture),
                    };
                }
                else if (args[i] == null)
                {

                }
                else
                {
                    arr[i] = new mpv_string()
                    {
                        value = args[i].ToString(),
                    };
                }
            }
            return arr;
        }
    }
}
