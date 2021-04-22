using System;
using System.Collections.Generic;
using UnitConverter.Logic;
using dbOperations;
namespace JIPP_1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            IConverter[] converters = new IConverter[]
            {
                new distance(),
                new temperature(),
                new mass()
            };
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.Clear();
                Console.WriteLine("Wybierz opcje:");
                for (int i = 0; i < converters.Length; ++i)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].name);
                }
                Console.WriteLine("({0}) Koniec", converters.Length + 1);
                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice);
                if (choice > converters.Length)
                {
                    shouldContinue = false;
                    continue;
                }
                Console.WriteLine("Podaj jednostke z:");
                string unitFrom = Console.ReadLine();
                Console.WriteLine("Podaj jednostke do:");
                string unitTo = Console.ReadLine();
                Console.WriteLine("Podaj liczbę do kowersji:");
                string inputVal = Console.ReadLine();
                decimal val = decimal.Parse(inputVal);

                decimal result = converters[choice - 1].Convert(val, unitFrom, unitTo);
                Console.WriteLine(result);
                Console.ReadKey();
            }
            /*            while (option!="4")
                        {
                            string message = "1. Konwerter temperatur \n2. Konwerter dystansu\n3. Konwerter masy\n4.Exit";
                            IDictionary<string, string> converters = new Dictionary<string, string>();
                            converters["1"] = "temperature";
                            converters["2"] = "distance";
                            converters["3"] = "mass";
                            Console.WriteLine(message);
                            option = Console.ReadLine();
                            if (option == "4")
                                break;
                            Type t = Type.GetType("JIPP_1." + converters[option]);
                            dynamic Converter = Activator.CreateInstance(t);
                            option = Converter.start();
                            Converter.convert(option);
                        }
                    }*/
        }
    }
}
