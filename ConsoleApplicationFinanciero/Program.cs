using System;
using System.Collections.Generic;
using System.Text;
using EcuacionesLib;
using FinancieroLib;

namespace ConsoleApplicationFinanciero
{
    class Program
    {
        static void Main(string[] args)
        {
            IValorActualNeto van = new VAN();

            van.Inversion = 2000000;

            for (int i = 0; i < 3; i++)
            {
                van.Pagos.Add(320000);
            }
            van.Pagos.Add(2320000);

            van.ResolverInterés();

            double rent = van.Rentabilidad;


            System.Console.ReadLine();
        }
    }
}
