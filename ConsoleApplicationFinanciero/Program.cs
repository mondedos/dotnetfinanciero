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
            
            
            System.Console.WriteLine(TAE.calcularTAEToString(0.115,12));
            System.Console.WriteLine(TAE.calcularInteres(0.0748, 12));
            System.Console.WriteLine(Pagos.mensualidad(17000.0,11.5,5));
            System.Console.ReadLine();
        }
    }
}
