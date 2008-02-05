using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    /// <summary>
    /// Tasa Anual Equivalente
    /// Se calcula como el resultado de una fórmula matemática normalizada que tiene en cuenta el tipo de interés,
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
        /// <param name="mesesAlAño">frecuencia de pagos al año</param>
        /// <returns></returns>
        public static double calcularTAE(double TIN, int mesesAlAño)
        {
            return Math.Pow((1 + (TIN / mesesAlAño)), mesesAlAño) - 1;
        }
        /// <summary>
        /// Desglosa el cálculo del tae
        /// </summary>
        /// <param name="TIN"></param>
        /// <param name="mesesAlAño"></param>
        /// <returns></returns>
        public static string calcularTAEToString(double TIN, int mesesAlAño)
        {
            System.Text.StringBuilder cad = new StringBuilder();

            cad.Append("(1+(tin/frecuencia))^frecuencia-1)=TAE\r\n");
            cad.Append("(1+(");
            cad.Append(TIN);
            cad.Append("/");
            cad.Append(mesesAlAño);
            cad.Append("))^");
            cad.Append(mesesAlAño);
            cad.Append("-1");
            return cad.ToString();
        }
        /// <summary>
        /// Calcula el interés que exige el banco
        /// </summary>
        /// <param name="tae">TAE anual</param>
        /// <param name="mesesAlAño">frecuencia de pagos al año</param>
        /// <returns></returns>
        public static double calcularInteres(double tae, int mesesAlAño)
        {
            return mesesAlAño * (Math.Pow((1 + tae), 1/(double)mesesAlAño) - 1);
        }
            
    }
}
