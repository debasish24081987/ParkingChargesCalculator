using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingChargeCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingChargeCalculator.Tests
{
    [TestClass()]
    public class ConcreteParkingFactoryTests
    {
        [TestMethod()]
        public void TestParkingTypeShortStay()
        {
            ConcreteParkingFactory shortStayParking = new ConcreteParkingFactory();
            var parkingType = shortStayParking.GetParkingType("Short Stay");
            double totalCharges = parkingType.CalculateParkingCharge(Convert.ToDateTime("07/09/2017 16:50:00"), 
                Convert.ToDateTime("09/09/2017 19:15:00"));
            Assert.AreEqual(Math.Round(totalCharges,2), 12.28);
        }

        [TestMethod()]
        public void TestParkingTypeLongStay()
        {
            ConcreteParkingFactory longStayParking = new ConcreteParkingFactory();
            var parkingType = longStayParking.GetParkingType("Long Stay");
            var totalCharges = parkingType.CalculateParkingCharge(Convert.ToDateTime("07/09/2017 16:50:00"), 
                Convert.ToDateTime("09/09/2017 19:15:00"));
            Assert.AreEqual(Math.Round(totalCharges, 2), 22.50);
        }

        [TestMethod()]
        public void TestParkingTypeOutsideChargeablePeriod()
        {
            ConcreteParkingFactory shortStayParking = new ConcreteParkingFactory();
            var parkingType = shortStayParking.GetParkingType("Short Stay");
            var totalCharges = parkingType.CalculateParkingCharge(Convert.ToDateTime("13/03/2021 16:50:00"),
                Convert.ToDateTime("14/03/2021 22:15:00"));
            Assert.AreEqual(0, 0);
        }
    }
}