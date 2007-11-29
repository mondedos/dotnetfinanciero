using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    public interface IValorActualNeto
    {
        /// <summary>
        /// Lista de pagos que se realizan durante n veces, ordenados desde el primer pago 
        /// hasta el último
        /// </summary>
        IList<double> Pagos { get;}
        /// <summary>
        /// Inversión inicial
        /// </summary>
        double Inversion { get;set;}
        /// <summary>
        /// Valor de la inflacion
        /// </summary>
        double Inflacion { get;set;}
        /// <summary>
        /// rentabilidad
        /// </summary>
        double Rentabilidad { get;set;}
        /// <summary>
        /// Años en los que se va a realizar los pagos
        /// </summary>
        int Años { get;set;}
        /// <summary>
        /// Meses en los que se realizarán los pagos
        /// </summary>
        int Meses { get;set;}
        /// <summary>
        /// Esta función resuelve el interés que se aplica en una inversión positiva o negativa.
        /// 
        /// Además invalida los datos de inflación e interés, por tanto si se quiere obtener el interes
        /// se deberá primero indicar la inflación (de no se así se supone inflación 0) y viceversa.
        /// </summary>
        void ResolverInterés();
    }
}
