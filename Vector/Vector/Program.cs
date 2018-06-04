using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector(3);
            v1.FillRnd(0, 10);
            var v2 = new Vector(3);
            v2.FillRnd(0, 10);
            Console.WriteLine(v1);
            Console.WriteLine(v2);
            var v3 = v1 + v2;
            Console.WriteLine(v3);
        }
    }
}
