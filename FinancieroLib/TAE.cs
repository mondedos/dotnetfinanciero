using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    /// <summary>
    /// Tasa Anual Equivalente
    /// Se calcula como el resultado de una f�rmula matem�tica normalizada que tiene en cuenta el tipo de inter�s,
    /// comisiones bancarias, frecuencia de los pagos (mensuales, trimestrales, etc.) y otros gastos o ingresos.
    /// </summary>
    public class TAE
    {
        public static bool Comprobar(double tae, double tin, double comisionApertura, double estudio, double cancelacionAnticipada)
        {
            return tae == (tin + comisionApertura + estudio + cancelacionAnticipada);
        }
        /// <summary>
        /// Realiza el calculo del TAE
        /// </summary>
        /// <param name="TIN">interes que exige el banco</param>
        /// <param name="mesesAlA�o">frecuencia de pagos al a�o</param>
        /// <returns></returns>
        public static double calcularTAE(double TIN, int mesesAlA�o)
        {
            return Math.Pow((1 + (TIN / mesesAlA�o)), mesesAlA�o) - 1;
        }
        /// <summary>
        /// Desglosa el c�lculo del tae
        /// </summary>
        /// <param name="TIN"></param>
        /// <param name="mesesAlA�o"></param>
        /// <returns></returns>
        public static string calcularTAEToString(double TIN, int mesesAlA�o)
        {
            System.Text.StringBuilder cad = new StringBuilder();

            cad.Append("(1+(tin/frecuencia))^frecuencia-1)=TAE\r\n");
            cad.Append("(1+(");
            cad.Append(TIN);
            cad.Append("/");
            cad.Append(mesesAlA�o);
            cad.Append("))^");
            cad.Append(mesesAlA�o);
            cad.Append("-1");
            return cad.ToString();
        }
        /// <summary>
        /// Calcula el inter�s que exige el banco
        /// </summary>
        /// <param name="tae">TAE anual</param>
        /// <param name="mesesAlA�o">frecuencia de pagos al a�o</param>
        /// <returns></returns>
        public static double calcularInteres(double tae, int mesesAlA�o)
        {
            return mesesAlA�o * (Math.Pow((1 + tae), 1/(double)mesesAlA�o) - 1);
        }
            
    }
}
