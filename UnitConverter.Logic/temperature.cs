using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class temperature : IConverter
    {
        public string name => "Temperatura";
        public List<string> units => new List<string>()
        {
           "C",
           "F",
           "K"
        };
        public decimal Convert(decimal valueToConvert, string unitFrom, string unitTo)
        {
            decimal result = 0;
            decimal multiple = 1;
            decimal add = 0;
            if (unitFrom == "F")
            {
                multiple = 0.555m;
                if (unitTo == "C")
                    add = -32;  
                if (unitTo == "K")
                    add = +459.67m;
            }
            if (unitTo == "F")
            {
                multiple = 1.8m;
                if (unitFrom == "C")
                    add = 32;
                if (unitFrom == "K")
                    add = -459.67m;
            }
            if (unitTo == "C" && unitFrom == "K")
                add = -273.15m; 
            if (unitTo == "K" && unitFrom == "C")
                add = 273.15m;
            result = valueToConvert*multiple+add;
            return result;
        }
    }
}
