using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace libmpv2net
{
    public class UnicodeBinaryString : IDisposable
    {
        private readonly IntPtr HGlobal;
        public UnicodeBinaryString(IntPtr hglobal)
        {
            this.HGlobal = hglobal; 
        }
        public static UnicodeBinaryString From(string txt)
        {
            var data = Encoding.UTF8.GetBytes(txt);
            var ptr = Marshal.AllocHGlobal(data.Length + 1);
            Marshal.Copy(data, 0, ptr, data.Length);
            Marshal.WriteByte(ptr, data.Length, 0);

            return new UnicodeBinaryString(ptr);
        }
        public void Dispose()
        {
            Marshal.FreeHGlobal(this.HGlobal);
        }
        public static implicit operator IntPtr(UnicodeBinaryString s)
        {
            return s.HGlobal;
        }
        public override string ToString()
        {
            return (string)HGlobal.ToObject(mpv_format.String);
        }
    }

    public static class UnicodeBinaryStringExtensions
    {
        public static UnicodeBinaryString ToMemory(this string txt)
        {
            return UnicodeBinaryString.From(txt);
        }
    }
}
