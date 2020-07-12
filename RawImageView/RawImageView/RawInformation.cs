using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawImageView
{
    public class RawInformation
    {
        public enum BitDepth
        {
            bitDepth_8bits,
            bitDepth_10bits,
            bitDepth_12bits,
            bitDepth_14bits,
            bitDepth_16bits
        }

        enum BitPosition
        {
            LSB,
            MSB
        }

        enum Endian
        {
            LITTLE,
            BIG
        }

        enum HeadColor
        {
            Red,
            Green_Red,
            Green_Blue,
            Blue
        }
    }
}
