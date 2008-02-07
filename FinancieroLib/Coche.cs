using System;
using System.Collections.Generic;
using System.Text;


///http://www.arpem.com/financia/calculadora/calculadora-gasolina-diesel.html
namespace FinancieroLib.Coches
{
    public abstract class Coche:ICloneable
    {
        double _precio, _consumo;
        int _caballos,_cc;

        string _modelo, _marca;

        public double Precio { get { return _precio; } set { _precio = value; } }
        public double Consumo { get { return _consumo; } set { _consumo = value; } }
        public int Caballos { get { return _caballos; } set { _caballos = value; } }
        public int CentimetrosCubicos { get { return _cc; } set { _cc = value; } }
        public string Modelo { get { return _modelo; } set { _modelo = value; } }
        public string Marca { get { return _marca; } set { _marca = value; } }
        public double CVF { get { return 0.11 * 0.6 * _cc; } }
        
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

            //calculo del coste por kilometro
            double costeDiesel = repostaje.PrecioDiesel * diesel.Consumo / 100;
            double costeGasolina = repostaje.PrecioGasolina * gasolina.Consumo / 100;

            double diferenciaCosteKm = costeGasolina - costeDiesel;

            return Math.Round(diferenciaPrecio / diferenciaCosteKm);
        }
        /// <summary>
        /// Obtiene el número de kilometros necesarios que hay que realizar para que el coche diesel
        /// sea mas rentable que el gasolina.
        /// </summary>
        /// <param name="gasolina"></param>
        /// <param name="diesel"></param>
        /// <param name="financiacionEquitativa">Forma de pago mediante crédito</param>
        /// <returns>numero de kilometros</returns>
        public static double ResolverObtenerKilometros(Gasolina gasolina, Diesel diesel, Financiacion financiacionEquitativa)
        {
            double beneficioBancoDiesel = Pagos.beneficio(diesel.Precio - financiacionEquitativa.Entrada, financiacionEquitativa.Interes, financiacionEquitativa.Años);
            double beneficioBancoGasolina = Pagos.beneficio(gasolina.Precio - financiacionEquitativa.Entrada, financiacionEquitativa.Interes, financiacionEquitativa.Años);

            Gasolina nuevoGasolina = (Gasolina)gasolina.Clone();
            nuevoGasolina.Precio = gasolina.Precio + beneficioBancoGasolina;

            Diesel nuevoDiesel = (Diesel)diesel.Clone();
            nuevoDiesel.Precio = diesel.Precio + beneficioBancoDiesel;

            return ResolverObtenerKilometros(nuevoGasolina, nuevoDiesel) ;
        }

        #region ICloneable Members

        protected void Clonar(Coche c)
        {
            c._caballos = _caballos;
            c._consumo = _consumo;
            c._marca = _marca;
            c._modelo = _modelo;
            c._precio = _precio;
        }

        public abstract object Clone();

        #endregion
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

    public class Financiacion
    {
        private double _interes, _tae,_entrada;
        private int _años;
        public double Interes { get { return _interes; } set { _interes = value; } }
        public double TAE { get { return _tae; } set { _tae = value; } }
        public double Entrada { get { return _entrada; } set { _entrada = value; } }
        public int Años { get { return _años; } set { _años = value; } }
    }

    public class Gasolina : Coche
    {
        public override object Clone()
        {
            Coche nuevo = new Gasolina();
            Clonar(nuevo);

            return nuevo;
        }
    }
    public class Diesel : Coche
    {
        public override object Clone()
        {
            Coche nuevo = new Diesel();
            Clonar(nuevo);

            return nuevo;
        }
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