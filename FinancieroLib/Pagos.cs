using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    /// <summary>
    /// Esta clase engloba los m�todos de calculo de mensualidades y otros calculos parecidos
    /// </summary>
    public class Pagos
    {
        /// <summary>
        /// Calcula la mensualidad a pagar durante el periodo establecido
        /// </summary>
        /// <param name="prestamo">cantidad de prestamos que se pide</param>
        /// <param name="interes">inter�s que aplica el banco</param>
        /// <param name="a�os">numero de a�os que se pretende alargar el prestamo</param>
        /// <returns>mensualidad</returns>
        public static double mensualidad(double prestamo, double interes, int a�os)
        {
            double meses  = a�os * 12;
            double rte = interes / 1200;
            double pmt = (rte + (rte / (Math.Pow((1 + rte), (meses)) - 1))) * prestamo;
            pmt = pmt * 100; pmt = Math.Round(pmt); pmt = pmt / 100;
            return pmt;
        }
        /// <summary>
        /// Calcula el beneficio que se lleva el banco supuesto un interes fijo
        /// </summary>
        /// <param name="prestamo">cantidad de prestamos que se pide</param>
        /// <param name="intereses">inter�s que aplica el banco</param>
        /// <param name="a�os">a�os que dura la hipoteca</param>
        /// <returns>beneficio que se lleva el banco</returns>
        public static double beneficio(double prestamo, double intereses, int a�os)
        {
            double mensualidad = mensualidad(prestamo, intereses, a�os);

            return a�os * 12 * mensualidad - prestamo;
        }
    }
}
