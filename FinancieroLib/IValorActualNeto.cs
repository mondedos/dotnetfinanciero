using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    public interface IValorActualNeto
    {
        /// <summary>
        /// Lista de pagos que se realizan durante n veces, ordenados desde el primer pago 
        /// hasta el �ltimo
        /// </summary>
        IList<double> Pagos { get;}
        /// <summary>
        /// Inversi�n inicial
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
        /// A�os en los que se va a realizar los pagos
        /// </summary>
        int A�os { get;set;}
        /// <summary>
        /// Meses en los que se realizar�n los pagos
        /// </summary>
        int Meses { get;set;}
        /// <summary>
        /// Esta funci�n resuelve el inter�s que se aplica en una inversi�n positiva o negativa.
        /// 
        /// Adem�s invalida los datos de inflaci�n e inter�s, por tanto si se quiere obtener el interes
        /// se deber� primero indicar la inflaci�n (de no se as� se supone inflaci�n 0) y viceversa.
        /// </summary>
        void ResolverInter�s();
    }
}
