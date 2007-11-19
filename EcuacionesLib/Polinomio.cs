using System;
using System.Collections.Generic;
using System.Text;

namespace EcuacionesLib
{
    public class Polinomio : IPolinomio
    {

        SortedList<double, Termino> _listaTerminos = new SortedList<double, Termino>();

        public Polinomio()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            foreach (Termino x in _listaTerminos.Values)
            {
                sb.Append(x.ToString());
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            try
            {
                Polinomio p = (Polinomio)obj;

                int total = _listaTerminos.Count;

                bool iguales = p._listaTerminos.Count == total;

                if (iguales)
                {
                    foreach (Termino t in _listaTerminos.Values)
                    {
                        iguales = iguales && t.Equals(p._listaTerminos[t.Exponente]);
                    }
                }

                return iguales;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        
        /// <summary>
        /// Encuentra la raiz aplicando el método de Newton
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="p"></param>
        /// <param name="p_derivada"></param>
        /// <returns></returns>
        public static double Newton(double a, double b, IPolinomio p)
        {
            IPolinomio p_derivada_primera = (IPolinomio)p.Clone(),p_derivada_segunda;
            p_derivada_primera.Derivar();
            p_derivada_segunda = (IPolinomio)p_derivada_primera.Clone();
            p_derivada_segunda.Derivar();

            double x_o ;
            double xn ;

            xn = b;
            if (p.Resolver(a) * p_derivada_segunda.Resolver(a) > 0)
            {
                xn = a;
            }
            x_o = xn + 1;

            while (xn != x_o)
            {
                x_o = xn;
                xn = x_o - p.Resolver(x_o) / p_derivada_primera.Resolver(x_o);
            }
            return xn;
        }

        #region IPolinomio Members

         void IPolinomio.Insertar(Termino t)
        {
            double exponente = t.Exponente;

            if (_listaTerminos.ContainsKey(exponente))
            {
                Termino t2 = _listaTerminos[exponente];
                t2.Multiplicando = t2.Multiplicando + t.Multiplicando;
            }
            else
            {
                _listaTerminos.Add(exponente, t);
            }
        }

         void IPolinomio.Intergrar()
        {
            SortedList<double, Termino> aux = new SortedList<double, Termino>();
            foreach (Termino x in _listaTerminos.Values)
            {
                x.Integrar();
                aux.Add(x.Exponente, x);
            }
            _listaTerminos = aux;
        }

         void IPolinomio.Derivar()
        {
            SortedList<double, Termino> aux = new SortedList<double, Termino>();
            foreach (Termino x in _listaTerminos.Values)
            {
                x.Derivar();
                aux.Add(x.Exponente, x);
            }
            _listaTerminos = aux;
        }


         double IPolinomio.Resolver(double x)
        {
            double v, ultimoExp;
            IList<Termino> lista = _listaTerminos.Values;
            int size = lista.Count;
            Termino[] terminos = new Termino[size];
            lista.CopyTo(terminos, 0);

            Termino t1 = terminos[size - 1];
            v = t1.Multiplicando;
            ultimoExp = t1.Exponente;

            for (int i = size - 2; i > -1; i--)
            {
                Termino t2 = terminos[i];

                double grado = t1.Exponente - t2.Exponente;

                v = v * Math.Pow(x, grado) + t2.Multiplicando;
                ultimoExp = t2.Exponente;
                t1 = t2;
            }
            v = v * Math.Pow(x, ultimoExp);
            return v;
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            Polinomio clon = new Polinomio();
            clon._listaTerminos = new SortedList<double, Termino>();

            foreach (Termino t in _listaTerminos.Values)
            {
                clon._listaTerminos.Add(t.Exponente, (Termino)((ICloneable)t).Clone());
            }

            return clon;
        }

        #endregion
    }
}
