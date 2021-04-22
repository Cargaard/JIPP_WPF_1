using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class mass :IConverter
    {
        public string name => "Masa";
        public List<string> units => new List<string>()
        {
           "KG",
           "LBS",
           "G"
        };
        public decimal Convert(decimal valueToConvert, string unitFrom, string unitTo)
        {
            decimal result = 0;

            return result;
        }

    }
}
