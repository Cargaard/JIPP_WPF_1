using System;
using System.Collections.Generic;
using System.Text;

namespace JIPP_1
{

    abstract class Converter
    {
      protected string message;
       protected string option;
        protected string[] units;
        protected double[] convertParams;
        public string start()
        {
            Console.Clear();
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        //abstract public void convert(string option);
        virtual public void convert(string option)
        {
            Console.WriteLine("Wprowadz wartosc: \n");
            string unit = "";
            double convertedValue = 0;
            string value = Console.ReadLine();
            switch (option)
            {
                case "1":
                    convertedValue = float.Parse(value) * convertParams[0];
                    unit = units[0];
                    break;
                case "2":
                    convertedValue = float.Parse(value) * convertParams[1]; ;
                    unit = units[1];
                    break;
            }
            Console.WriteLine("Wartosc po przekonwertowaniu to: " + convertedValue + unit);
        }
    }
}
