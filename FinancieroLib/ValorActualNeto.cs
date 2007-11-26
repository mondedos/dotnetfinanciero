using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    public class VAN:IValorActualNeto
    {
        IList<double> _pagos;
        double _inversion = 0;
        double _XunoMasK = 0;

        public VAN(double inversion, IList<double> pagos)
        {
            _inversion = inversion;
            _pagos = pagos;
        }
        public VAN(double inversion) : this(inversion, new List<double>()) { }

        public VAN() : this(0) { }



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
                _inversion=value;
            }
        }

        #endregion
    }
}
