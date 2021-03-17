using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingChargeCalculator
{
    class Program
    {
        private static readonly CultureInfo UnitedKingdom = CultureInfo.GetCultureInfo("en-GB");
        static void Main(string[] args)
        {
            DateTime checkInTime;
            DateTime checkOutTime;
            string stayType;

            Console.WriteLine("Welcome to XYZ Car Parking");
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Please enter the check-in time.");
            checkInTime = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter the check-out time.");
            checkOutTime = Convert.ToDateTime(Console.ReadLine());

            if(checkInTime > checkOutTime)
            {
                Console.WriteLine("Incorrect checkout time, application will exit.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter the type of stay.");
            stayType = Console.ReadLine();

            AbstractParkingFactory factory = new ConcreteParkingFactory();
            IParkingCharge parkingTypeCharge = factory.GetParkingType(stayType);
            var totalCharges = parkingTypeCharge.CalculateParkingCharge(checkInTime, checkOutTime);

            Console.WriteLine("Total Parking Cost is: {0}", totalCharges.ToString("C", UnitedKingdom));
            Console.ReadLine();
        }
    }
}
