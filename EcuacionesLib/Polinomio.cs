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

        #region IPolinomio Members

        public void Insertar(Termino t)
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

        public void Intergrar()
        {
            SortedList<double, Termino> aux = new SortedList<double, Termino>();
            foreach (Termino x in _listaTerminos.Values)
            {
                x.Integrar();
                aux.Add(x.Exponente, x);
            }
            _listaTerminos = aux;
        }

        public void Derivar()
        {
            SortedList<double, Termino> aux = new SortedList<double, Termino>();
            foreach (Termino x in _listaTerminos.Values)
            {
                x.Derivar();
                aux.Add(x.Exponente, x);
            }
            _listaTerminos = aux;
        }

        #endregion

        #region IPolinomio Members


        public double Resolver(double x)
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
    }
}
