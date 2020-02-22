using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialColors.Data
{
    public class SColor
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public SColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public SColor(ulong encodedColor)
        {
            SetColor(encodedColor);
        }

        public void SetColor(ulong encodedColor)
        {
            SColor temp = DecodeColor(encodedColor);
            Red = temp.Red;
            Green = temp.Green;
            Blue = temp.Blue;
        }

        public ulong EncodeColor(SColor color)
        {
            ulong uiColor = (ulong)color.Red   << 16 |
                            (ulong)color.Green <<  8 |
                            (ulong)color.Blue;
            return uiColor;
        }
        public SColor DecodeColor(ulong ulColor)
        {
            return new SColor 
            (
                (byte)(ulColor >> 16),
                (byte)(ulColor >> 8),
                (byte)ulColor
            );
        }

        public ulong ToUlong()
        {
            return EncodeColor(this);
        }
    }

    

   

}
