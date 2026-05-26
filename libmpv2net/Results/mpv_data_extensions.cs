using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    public static class mpv_data_extensions
    {
        public static object ToObject(this mpv_node_pointer ptr, mpv_format fmt)
        {
            switch (fmt)
            {
                case mpv_format.None:
                    return null;
                case mpv_format.String:
                    return Marshal.PtrToStringUni(ptr.handle);
                case mpv_format.OsdString:
                    return Marshal.PtrToStringUni(ptr.handle);
                case mpv_format.BoolFlag:
                    return ptr.handle != IntPtr.Zero;
                case mpv_format.Long:
                    return ptr.handle.ToInt64();
                case mpv_format.Double:
                    var bytes = BitConverter.GetBytes(ptr.handle.ToInt64());
                    var dbl = BitConverter.ToDouble(bytes, 0);
                    return dbl;
                case mpv_format.Node:
                    var nodeAny = (mpv_node_unknown)Marshal.PtrToStructure(
                        ptr.handle, typeof(mpv_node_unknown));
                    return nodeAny.AnyData.ToObject(nodeAny.Format);
                case mpv_format.NodeArray:
                    var nodeArr = (mpv_node_list)Marshal.PtrToStructure(
                        ptr.handle, typeof(mpv_node_list));
                    object[] targetArray = new object[nodeArr.num];
                    for (int i = 0; i < nodeArr.num; i++)
                    {
                        var subnode = nodeArr.values[i];
                        targetArray[i] = subnode.AnyData.ToObject(subnode.Format);
                    }
                    return targetArray;
                case mpv_format.NodeMap:
                    var nodeMap = (mpv_node_map)Marshal.PtrToStructure(
                        ptr.handle, typeof(mpv_node_map));
                    var outMap = new Dictionary<string, object>();
                    for (int i = 0; i < nodeMap.num; i++)
                    {
                        var key = nodeMap.keys[i];
                        var subNode = nodeMap.values[i];
                        outMap[key.value] = subNode.AnyData.ToObject(subNode.Format);
                    }
                    return outMap;
                case mpv_format.ByteArray:
                    var srcArr = (mpv_byte_array_64)Marshal.PtrToStructure(
                        ptr.handle, typeof(mpv_byte_array_64));
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
