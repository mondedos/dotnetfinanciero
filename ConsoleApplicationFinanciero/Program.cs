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
                        Termino t1 = new Termino(1, 4);
            Termino t2 = new Termino(-1, 3);
            Termino t3 = new Termino(-3, 2);
            Termino t4 = new Termino(-4, 1);
            Termino t5 = new Termino(-2, 0);

            IPolinomio p1 = new EcuacionesLib.Polinomio();
            p1.Insertar(t1);
            p1.Insertar(t2);
            p1.Insertar(t3);

            p1.Insertar(t4);
            p1.Insertar(t5);
            //p2.Insertar(t3);
            System.Console.WriteLine(EcuacionesLib.Polinomio.Newton(2, 3, p1));

            System.Console.ReadLine();
        }
    }
}
