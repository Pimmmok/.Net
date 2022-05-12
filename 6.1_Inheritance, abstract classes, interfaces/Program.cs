using System;

namespace _6._1_Inheritance__abstract_classes__interfaces
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Program converter and code checker");
            ProgramConverter[] programConverters = { new ProgramConverter(), new ProgramHelper(),
                new ProgramConverter(), new ProgramHelper(), new ProgramHelper()};
            string line = new string("line of code C#");
            for (int i = 0; i < programConverters.Length; i++)
            {
                string lineVB = programConverters[i].ConvertToVB(line);
                Console.WriteLine(new string('=', 57));
                if (programConverters[i] is ICodeChecker temp)
                {
                    Console.WriteLine("Element " + i.ToString() + " in array implements an interface ICodeChecker:");
                    Console.WriteLine(lineVB + " Code matches VB: " + temp.CheckCodeSyntax(lineVB, "VB").ToString());
                }
                else
                {
                    Console.WriteLine("Element " + i.ToString() + " in array not implements an interface ICodeChecker");
                }
            }
        }
    }
}
