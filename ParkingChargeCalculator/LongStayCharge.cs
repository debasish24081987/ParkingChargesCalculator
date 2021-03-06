using System;

namespace ParkingChargeCalculator
{
    public class LongStayCharge : IParkingCharge
    {
        const double minChargeOneDay = 7.50;
        public double CalculateParkingCharge(DateTime inTime, DateTime outTime)
        {
            Console.WriteLine("Customer is charged for Long Stay.");
            var days = (outTime.Day - inTime.Day) + 1;
            return (days * minChargeOneDay);
        }
    }
}
