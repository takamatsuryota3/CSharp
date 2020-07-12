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
            bitDepth_8bits =8,
            bitDepth_10bits = 10,
            bitDepth_12bits = 12,
            bitDepth_14bits = 14,
            bitDepth_16bits = 16
        }

        public enum BitPosition
        {
            LSB,
            MSB
        }

        public enum Endian
        {
            LITTLE,
            BIG
        }

        public enum HeadColor
        {
            Red,
            Green_Red,
            Green_Blue,
            Blue
        }
    }
}
