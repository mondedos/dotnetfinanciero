using System;
using System.Collections.Generic;
using System.Text;
using EcuacionesLib;

namespace ConsoleApplicationFinanciero
{
    class Program
    {
        static void Main(string[] args)
        {
            Termino t1 = new Termino(2, 2);
            Termino t2 = new Termino(3, 3);
            Termino t3 = new Termino(3, 0);

            Polinomio p = new Polinomio();
            p.Insertar(t1);
            p.Insertar(t2);
            p.Insertar(t3);

            System.Console.WriteLine(p);
            System.Console.WriteLine(p.Resolver(2));
            p.Derivar();
            System.Console.WriteLine(p);
            System.Console.WriteLine(p.Resolver(2));
            p.Intergrar();
            System.Console.WriteLine(p);
            System.Console.WriteLine(p.Resolver(2));

            System.Console.ReadLine();
        }
    }
}
