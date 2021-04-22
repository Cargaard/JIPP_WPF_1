using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public interface IConverter
    {
        string name { get; }
        List <string> units { get; }
        decimal Convert(decimal valueToConvert, string unitFrom, string unitTo);
    }
}
