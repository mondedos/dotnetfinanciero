using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    public class VAN:IValorActualNeto
    {
        IList<double> _pagos;
        double _inversion = 0;

        public VAN(double inversion, IList<double> pagos)
        {
            _inversion = inversion;
            _pagos = pagos;
        }
        public VAN(double inversion) : this(inversion, new List<double>()) { }

        public VAN() : this(0) { }

    }
}
