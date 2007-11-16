using System;
using System.Collections.Generic;
using System.Text;

namespace EcuacionesLib
{
    interface IPolinomio
    {
        /// <summary>
        /// Inserta un término en el polinomio
        /// </summary>
        /// <param name="x"></param>
        void Insertar(Termino x);
        /// <summary>
        /// Calcula la integral del polinomio
        /// </summary>
        void Intergrar();
        /// <summary>
        /// Calcula la derivada del polinomio
        /// </summary>
        void Derivar();
        /// <summary>
        /// Resuelve el polinomio sustituyendo x por su valor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double Resolver(double x);

    }
}
