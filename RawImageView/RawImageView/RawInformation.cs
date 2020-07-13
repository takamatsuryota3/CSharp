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
            depth_8bits =8,
            depth_10bits = 10,
            depth_12bits = 12,
            depth_14bits = 14,
            depth_16bits = 16
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
