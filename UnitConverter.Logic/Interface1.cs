using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public interface IConverterSpecial
    {
        string name { get; }
        string Convert(string valueToConvert);
    }
}
