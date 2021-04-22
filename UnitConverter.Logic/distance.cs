using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class distance : IConverter
    {
        public string name => "Dystans";
        public List<string> units => new List<string>()
        {
            "KM",
            "MIL"
        };
        public decimal Convert(decimal valueToConvert, string unitFrom, string unitTo)
        {
            return 10;
        }

    }
}
