using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EcuacionesLib;

namespace EcuacionesLibTest.Unitarias
{
    [TestFixture]
    public class PolinomioTest
    {
                [TestFixtureSetUp]
        public void SettingUp()
        {
            
        }
        [TestFixtureTearDown]
        public void TearDowning()
        {
            
        }
        [Test]
        public void TestEquals()
        {
            Termino t1 = new Termino(2, 2);
            Termino t2 = new Termino(3, 3);
            Termino t3 = new Termino(3, 0);

            IPolinomio p1 = new EcuacionesLib.Polinomio();
            IPolinomio p2 = new EcuacionesLib.Polinomio();
            p1.Insertar(t1);
            p1.Insertar(t2);
            p1.Insertar(t3);

                        p2.Insertar(t1);
            p2.Insertar(t2);
            p2.Insertar(t3);

            Assert.IsTrue(p1.Equals(p2));
        }
        [Test]
        public void TestEquals2()
        {
            Termino t1 = new Termino(2, 2);
            Termino t2 = new Termino(3, 3);
            Termino t3 = new Termino(3, 0);

            IPolinomio p1 = new EcuacionesLib.Polinomio();
            IPolinomio p2 = new EcuacionesLib.Polinomio();
            p1.Insertar(t1);
            p1.Insertar(t2);
            p1.Insertar(t3);

            p2.Insertar(t1);
            p2.Insertar(t2);
            //p2.Insertar(t3);

            Assert.IsFalse(p1.Equals(p2));
        }

        [Test]
        public void Newton()
        {
            Termino t1 = new Termino(1, 4);
            Termino t2 = new Termino(-1, 3);
            Termino t3 = new Termino(-3, 2);
            Termino t4 = new Termino(-4, 1);
            Termino t5 = new Termino(-2, 0);

            IPolinomio p1 = new EcuacionesLib.Polinomio();
            IPolinomio p2;
            p1.Insertar(t1);
            p1.Insertar(t2);
            p1.Insertar(t3);

            p1.Insertar(t4);
            p1.Insertar(t5);
            //p2.Insertar(t3);
            p2 = (IPolinomio)p1.Clone();
            p2.Derivar();

            Assert.IsTrue((int)p1.Resolver(EcuacionesLib.Polinomio.Newton(2,3,p1))==0);
        }
    }
}
