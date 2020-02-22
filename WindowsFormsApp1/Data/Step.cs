using System;
using System.Collections.Generic;

namespace SerialColors.Data
{
    public class Step
    {
        public int From { get; set; }
        public int To { get; set; }
        public ulong Color { get; set; }

        public Step(string stepString)
        {
            var values = new List<string>(stepString.Split(new char[] { ';' }));
            From = int.Parse(values[0]);
            To = int.Parse(values[1]);
            Color = UInt64.Parse(values[2]);
        }
        public Step()
        {
            From = 0;
            To = 0;
            Color = 0;
        }


        public override string ToString()
        {
            return $"{From};{To};{Color}";
        }
    }
}
