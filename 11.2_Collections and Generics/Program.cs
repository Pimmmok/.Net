using System;

namespace _11._2_Collections_and_Generics
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Abstract factory");
            Factory1 factory1 = new Factory1();
            Factory2 factory2 = new Factory2();
            Client client1 = new Client(factory1);
            Client client2 = new Client(factory2);
            Console.WriteLine(client1.GetNameProductA());
            Console.WriteLine(client1.GetNameProductB());
            Console.WriteLine(client2.GetNameProductA());
            Console.WriteLine(client2.GetNameProductB());
        }
    }
}
