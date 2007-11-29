using System;
using System.Collections.Generic;
using System.Text;
using EcuacionesLib;

namespace FinancieroLib
{
    public class VAN : IValorActualNeto
    {
        IList<double> _pagos;
        double _inversion = 0;
        double _XunoMasK = 0, _r = 0, _i = 0;
        int _meses;
        bool _interesValido = true;

        public VAN(double inversion, IList<double> pagos)
        {
            _inversion = inversion;
            _pagos = pagos;
        }
        public VAN(double inversion) : this(inversion, new List<double>()) { }

        public VAN() : this(0) { }

        private IPolinomio construirPolinomio()
        {
            IPolinomio p = new Polinomio();

            //suponemos los pagos ordenados desde el primer mes hasta el ultimo
            int maxExponente = _pagos.Count;

            p.Insertar(new Termino(-_inversion, maxExponente));
            foreach (double qn in _pagos)
            {
                maxExponente--;
                p.Insertar(new Termino(qn, maxExponente));
            }

            return p;
        }

        private double calcularCotaSup(double S, double D)
        {
            double res = (S / _inversion);
            res = Math.Pow(res, D / S);
            return res;
        }

        private double calcularCotaInf(double S, double M)
        {
            double res = (S / _inversion);
            res = Math.Pow(res, S / M);
            return res;
        }

        private void calcularS_M_D(ref double S, ref double M,ref double D)
        {
            S = 0;
            M = 0;
            D = 0;

            int t = 1;

            foreach (double Q in _pagos)
            {
                S += Q;
                M += t * Q;
                D += Q / t;

                t++;
            }
        }
        #region IValorActualNeto Members

        IList<double> IValorActualNeto.Pagos
        {
            get
            {
                return _pagos;
            }
        }

        double IValorActualNeto.Inversion
        {
            get
            {
                return _inversion;
            }
            set
            {
                _inversion = value;
            }
        }
        double IValorActualNeto.Inflacion
        {
            get
            {
                return _i;
            }
            set
            {
                _interesValido = true;
                _i = value;
            }
        }

        double IValorActualNeto.Rentabilidad
        {
            get
            {
                if (_interesValido)
                    return _r;
                else
                {
                    double sol = (_XunoMasK / (1 + _i)) - 1;
                    return sol;
                }
            }
            set
            {
                _interesValido = true;
                _r = value;
            }
        }

        int IValorActualNeto.Años
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IValorActualNeto.Meses
        {
            get
            {
                return _meses;
            }
            set
            {
                _meses = value;
            }
        }
        void IValorActualNeto.ResolverInterés()
        {
            double S = 0, M = 0, D = 0, cotaInf, cotaSup;
            IPolinomio p = this.construirPolinomio();

            calcularS_M_D(ref S, ref M, ref D);

            cotaInf = this.calcularCotaInf(S, M);
            cotaSup = this.calcularCotaSup(S, D);

            _XunoMasK = Polinomio.Newton(cotaInf, cotaSup, p);

            //double b = p.Resolver(1.16);
            _i = 0;
            _r = 0;
            _interesValido = false;
        }

        #endregion
    }
}
