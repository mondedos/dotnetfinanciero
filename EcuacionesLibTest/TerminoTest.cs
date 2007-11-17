using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EcuacionesLib;

namespace EcuacionesLibTest.Unitarias
{
    [TestFixture]
    public class TerminoTest
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
        public void TestingIntegral()
        {
            Termino t1 = new Termino(3, 3);

            Termino t2 = new Termino(9, 2);

            t2.Integrar();

            Assert.IsTrue(t1.Equals(t2));
        }
        [Test]
        public void TestingDerivada()
        {
            Termino t1 = new Termino(3, 3);

            Termino t2 = new Termino(9, 2);

            t1.Derivar();

            Assert.IsTrue(t1.Equals(t2));
        }
    }
}
