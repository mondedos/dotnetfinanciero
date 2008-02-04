using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EcuacionesLib;
using FinancieroLib;

namespace EcuacionesLibTest.Unitarias
{
    [TestFixture]
    public class VanTest
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
        public void Test16PorCiento()
        {
            IValorActualNeto van = new VAN();

            van.Inversion = 2000000;

            for (int i = 0; i < 3; i++)
            {
                van.Pagos.Add(320000);
            }
            van.Pagos.Add(2320000);

            van.ResolverInterés();

            double rent = van.Rentabilidad;

            Assert.AreEqual("0,16", rent.ToString());
        }
        [Test]
        public void Test14PorCiento()
        {
            IValorActualNeto van = new VAN();

            van.Inversion = 2000;


            van.Pagos.Add(1000);
            van.Pagos.Add(800);
            van.Pagos.Add(600);
            van.Pagos.Add(200);


            van.ResolverInterés();

            //van.Inflacion = 0.06;

            double rent = van.Rentabilidad;

            Assert.AreEqual(14.0, Math.Floor(rent * 100));
        }
        [Test]
        public void Test11PorCiento()
        {
            IValorActualNeto van = new VAN();

            van.Inversion = 2000;


            van.Pagos.Add(200);
            van.Pagos.Add(600);
            van.Pagos.Add(800);
            van.Pagos.Add(1200);


            van.ResolverInterés();

            //van.Inflacion = 0.06;

            double rent = van.Rentabilidad;

            Assert.AreEqual(11.0, Math.Floor(rent * 100));
        }
    }
}
