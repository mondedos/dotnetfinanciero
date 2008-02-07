using System;
using System.Collections.Generic;
using System.Text;
using EcuacionesLib;
using FinancieroLib;
using FinancieroLib.Coches;

namespace ConsoleApplicationFinanciero
{
    class Program
    {
        static void Main(string[] args)
        {
            Financiacion pago = new Financiacion();
            pago.Años = 5;
            pago.Entrada = 3000;
            pago.Interes = 11.5;

            Gasolinera punto = Gasolinera.GetInstance();
            punto.PrecioGasolina = 1.08;
            punto.PrecioDiesel = 0.99;

            Gasolina fiesta13 = new Gasolina();
            fiesta13.Caballos = 70;
            fiesta13.Consumo = 8.1;
            fiesta13.Precio = 13030.0;

            Diesel fiesta14 = new Diesel();
            fiesta14.Caballos = 68;
            fiesta14.Consumo = 5.8;
            fiesta14.Precio = 13635.0;



            System.Console.WriteLine(Coche.ResolverObtenerKilometros(fiesta13, fiesta14,pago)); 
            Gasolina fiesta16 = new Gasolina();
            fiesta16.Caballos = 100;
            fiesta16.Consumo = 8.8;
            fiesta16.Precio = 14635.0;

            Diesel fiesta16g = new Diesel();
            fiesta16g.Caballos = 90;
            fiesta16g.Consumo = 5.2;
            fiesta16g.Precio = 14935.0;



            System.Console.WriteLine(Coche.ResolverObtenerKilometros(fiesta16, fiesta16g,pago));

            System.Console.ReadLine();
        }
    }
}
