using System;
using System.Collections.Generic;
using System.Text;

namespace EcuacionesLib
{
    public class Termino:ICloneable
    {
        double _multiplicando;
        double _exponente;

        public Termino(double multiplicando, double exponente)
        {
            _multiplicando = multiplicando;
            _exponente = exponente;
        }
        public Termino(double multiplicando) : this(multiplicando, 0) { }
        public Termino() : this(0, 0) { }

        public double Multiplicando
        {
            get { return _multiplicando; }
            set { _multiplicando = value; }
        }
        public double Exponente
        {
            get { return _exponente; }
            set { _exponente = value; }
        }
        public void Derivar()
        {
            _multiplicando = _multiplicando * _exponente;
            _exponente--;
        }
        public void Integrar()
        {
            _exponente++;
            _multiplicando = _multiplicando / _exponente;
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            if(_multiplicando>0)
                sb.Append("+");
            sb.Append(_multiplicando.ToString());
            if(_exponente!=0){
            sb.Append( "x^");
            sb.Append( _exponente.ToString());}
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            try
            {
                Termino t = (Termino)obj;
                return _exponente == t._exponente && _multiplicando == t._multiplicando;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        //public static Termino operator+(Termino t1,Termino t2){
        //    Termino t = new Termino(t1._multiplicando + t2._multiplicando, t1._exponente);
        //    return t;
        //}

        #region ICloneable Members

        object ICloneable.Clone()
        {
            Termino clon = new Termino();

            clon._exponente = _exponente;
            clon._multiplicando = _multiplicando;
            return clon;
        }

        #endregion
    }
}
