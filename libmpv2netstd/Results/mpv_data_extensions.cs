using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    public static class mpv_data_extensions
    {
        private static string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0) ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static object ToObject(this IntPtr ptr, mpv_format fmt)
        {
            switch (fmt)
            {
                case mpv_format.None:
                    return null;
                case mpv_format.String:
                case mpv_format.OsdString:
                    return StringFromNativeUtf8(ptr);
                case mpv_format.BoolFlag:
                    return (ptr.ToInt64() & 0b1) > 0;
                case mpv_format.Long:
                    return ptr.ToInt64();
                case mpv_format.Double:
                    var bytes = BitConverter.GetBytes(ptr.ToInt64());
                    var dbl = BitConverter.ToDouble(bytes, 0);
                    return dbl;
                case mpv_format.Node:
                    var nodeAny = (mpv_node_unknown)Marshal.PtrToStructure(
                        ptr, typeof(mpv_node_unknown));
                    return nodeAny.Data.ToObject(nodeAny.Format);
                case mpv_format.NodeArray:
                    var nodeArr = (mpv_node_list)Marshal.PtrToStructure(
                        ptr, typeof(mpv_node_list));
                    object[] targetArray = new object[nodeArr.num];
                    for (int i = 0; i < nodeArr.num; i++)
                    {
                        var subnode = nodeArr.values[i];
                        targetArray[i] = subnode.Data.ToObject(subnode.Format);
                    }
                    return targetArray;
                case mpv_format.NodeMap:
                    /*
                    var nodeMap = (mpv_node_map)Marshal.PtrToStructure(
                        ptr, typeof(mpv_node_map));
                    var outMap = new Dictionary<string, object>();
                    for (int i = 0; i < nodeMap.num; i++)
                    {
                        var key = nodeMap.keys[i];
                        var subNode = nodeMap.values[i];
                        outMap[key.value] = subNode.Data.ToObject(subNode.Format);
                    }
                    return outMap; 
                    */
                    throw new NotSupportedException();
                case mpv_format.ByteArray:
                    var srcArr = (mpv_byte_array_64)Marshal.PtrToStructure(
                        ptr, typeof(mpv_byte_array_64));
                    var dstArr = new byte[srcArr.size];
                    Array.Copy(srcArr.data, dstArr, srcArr.size);
                    return dstArr;
                default:
                    Console.Error.WriteLine("Received unsupported data format");
                    return null;
            }
        }
    }
}
