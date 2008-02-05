using System;
using System.Collections.Generic;
using System.Text;


///http://www.arpem.com/financia/calculadora/calculadora-gasolina-diesel.html
namespace FinancieroLib.Coches
{
    public abstract class Coche
    {
        double _precio, _consumo;
        int _caballos;

        string _modelo, _marca;

        public double Precio { get { return _precio; } set { _precio = value; } }
        public double Consumo { get { return _consumo; } set { _consumo = value; } }
        public int Caballos { get { return _caballos; } set { _caballos = value; } }
        public string Modelo { get { return _modelo; } set { _modelo = value; } }
        public string Marca { get { return _marca; } set { _marca = value; } }

        /// <summary>
        /// Obtiene la cantidad de kilómetros a partir del cual, la versión del motor diesel es mas
        /// rentable que el gasolina.
        /// </summary>
        /// <param name="gasolina"></param>
        /// <param name="diesel"></param>
        /// <returns>kilometros</returns>
        public static double ResolverObtenerKilometros(Gasolina gasolina, Diesel diesel)
        {
            double diferenciaPrecio = diesel.Precio - gasolina.Precio;

            Gasolinera repostaje = Gasolinera.GetInstance();

            //calculo a los 100km
            double costeDiesel = repostaje.PrecioDiesel * diesel.Consumo / 100;
            double costeGasolina = repostaje.PrecioGasolina * gasolina.Consumo / 100;

            double diferenciaCosteKm = costeGasolina - costeDiesel;

            return Math.Round(diferenciaPrecio / diferenciaCosteKm);
        }
    }
    public class Gasolinera
    {
        private static object o = new object();
        private static Gasolinera _instance = null;
        private double _precioGasolina, _precioDiesel;
        public double PrecioGasolina { get { return _precioGasolina; } set { _precioGasolina = value; } }
        public double PrecioDiesel { get { return _precioDiesel; } set { _precioDiesel = value; } }
        private Gasolinera()
        {
        }

        public static Gasolinera GetInstance()
        {
            lock (o)
            {
                if (_instance == null)
                    _instance = new Gasolinera();
            }
            return _instance;
        }
    }


    public class Gasolina : Coche
    {
    }
    public class Diesel : Coche
    {
    }

}
/*


costekmdiesel=preciolitrodiesel*consumodiesel/100;
costekmgasolina=preciolitrogasolina*consumogasolina/100;

diferenciacostekm=costekmgasolina-costekmdiesel;

km=diferenciaprecio/diferenciacostekm;



<!-- limitamos el número de decimales a cero -->
km=Math.round(km);


<!-- devolvemos el resultado de la operacion de los kilometros -->
form.resultado.value=km+" km";

<!-- calculamos el tiempo en años -->
anos=km/kmanuales;
anosexactos=parseInt (anos, 10)

<!-- calculamos el tiempo en meses -->
decimales=anos-anosexactos;
meses=decimales*12;
mesesexactos=parseInt (meses, 10)


<!-- devolvemos el resultado del tiempo -->
form.tiempo.value=anosexactos+" años"+" y "+mesesexactos+" meses";


}
*/