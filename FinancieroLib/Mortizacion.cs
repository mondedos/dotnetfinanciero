using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieroLib
{
    public class Prestamo
    {
        ICollection<ItemAmortizacion> _listaAmortizacion;
        double _mensualidad = 0, _capital, _interes, _comisionApertura;
        int _años;
        bool _restarComisionApertura = true;
        IValorActualNeto van;
        public bool RestarComisionApertura { get { return _restarComisionApertura; } set { _restarComisionApertura = value; } }
        public ICollection<ItemAmortizacion> Desglose { get { return _listaAmortizacion; } }
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="capital">Capital del prestamo que se solicita</param>
        /// <param name="interes">interes requerido por el banco en %</param>
        /// <param name="años">años que durará el préstamo</param>
        public Prestamo(double capital, double interes, int años)
        {
            _capital = capital;
            _interes = interes;
            _años = años;

            van = new VAN();

            van.Inversion = capital;

            CalcularAmortización();
        }
        /// <summary>
        /// Comisión de apertura del préstamo expresado en %
        /// </summary>
        public double ComisiónApertura
        {
            get { return _comisionApertura; }
            set
            {
                _comisionApertura = value;
                if (_restarComisionApertura)
                    van.Inversion = _capital - _capital * (_comisionApertura / 100);
                else
                    van.Inversion = _capital + _capital * (_comisionApertura / 100);
            }
        }

        public double RentabilidadReal()
        {
            van.ResolverInterés();
            return van.Rentabilidad;
        }

        public void CalcularAmortización()
        {

            int totalMeses = _años * 12, año = 1, mes = 2;

            _mensualidad = Pagos.mensualidad(_capital, _interes, _años);
            double interesDecimal = (_interes / 100) / 12;

            _listaAmortizacion = new List<ItemAmortizacion>();

            ItemAmortizacion itemAnterior = new ItemAmortizacion(año, 1, _capital, interesDecimal, _mensualidad, 0);
            van.Pagos.Add(_mensualidad);
            _listaAmortizacion.Add(itemAnterior);

            for (int i = 0; i < totalMeses - 1; i++)
            {
                if (mes == 12)
                {
                    año++;
                    mes = 1;
                }
                ItemAmortizacion item = new ItemAmortizacion(año, mes, itemAnterior.Capital, interesDecimal, _mensualidad, itemAnterior.CapitalAmortizado);

                if (i == totalMeses - 2)
                {
                    //ultimo mes
                    double ultimacuota = Math.Round((_mensualidad + item.Capital) * 100) / 100;
                    item = new ItemAmortizacion(año, mes, itemAnterior.Capital, interesDecimal, ultimacuota, itemAnterior.CapitalAmortizado);
                }
                itemAnterior = item;
                _listaAmortizacion.Add(itemAnterior);

                van.Pagos.Add(_mensualidad);
                mes++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Mensualidad del préstamo -> " + _mensualidad);

            foreach (ItemAmortizacion v in _listaAmortizacion)
            {
                sb.AppendLine(v.ToString());
            }
            return sb.ToString();
        }
    }

    public class ItemAmortizacion
    {
        int _mes, _año;

        double _cuota, _interes, _amortizacion, _capital, _amortizado;

        public ItemAmortizacion(int año, int mes, double capital_restante, double interes, double mensualidad, double amortizado)
        {
            _mes = mes;
            _año = año;
            _interes = capital_restante * interes;
            _amortizacion = mensualidad - _interes;
            _amortizado = _amortizacion + amortizado;
            _capital = capital_restante - _amortizacion;
            _cuota = mensualidad;
        }

        #region Propiedades

        public int Año { get { return _año; } set { _año = value; } }
        public int Mes { get { return _mes; } set { _mes = value; } }
        public double Cuota { get { return _cuota; } set { _cuota = value; } }
        public double Interes { get { return _interes; } set { _interes = value; } }
        public double Amortización { get { return _amortizacion; } set { _amortizacion = value; } }
        public double Capital { get { return _capital; } set { _capital = value; } }
        public double CapitalAmortizado { get { return _amortizado; } set { _amortizado = value; } }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Año = ");
            sb.Append(_año);
            sb.Append(" ,Mes = ");
            sb.Append(_mes);
            sb.Append(" ,Cuota = ");
            sb.Append(_cuota);
            sb.Append(" ,Interes = ");
            sb.Append(_interes);
            sb.Append(" ,Amortizacion = ");
            sb.Append(_amortizacion);
            sb.Append(" ,Capital = ");
            sb.Append(_capital);
            sb.Append(" ,Capital Amortizado = ");
            sb.Append(_amortizado);
            sb.Append(">");
            return sb.ToString();
        }
    }
}
