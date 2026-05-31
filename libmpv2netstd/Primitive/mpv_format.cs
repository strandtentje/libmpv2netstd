using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public enum mpv_format
    {
        None = 0,
        String = 1,
        OsdString = 2,
        BoolFlag = 3,
        Long = 4,
        Double = 5,
        Node = 6,
        NodeArray = 7,
        NodeMap = 8,
        ByteArray = 9,
    }
}
