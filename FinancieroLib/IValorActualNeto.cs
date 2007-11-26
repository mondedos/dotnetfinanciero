using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    public interface IValorActualNeto
    {
        IList<double> Pagos { get;}
        double Inversion { get;set;}
    }
}
