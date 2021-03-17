using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingChargeCalculator
{
    public class ShortStayCharge : IParkingCharge
    {
       // TimeSpan minSpan = new TimeSpan(1, 2, 1, 0, 0);
        //TimeSpan maxSpan = new TimeSpan(1, 2, 1, 0, 0);

        public double CalculateParkingCharge(DateTime inTime, DateTime outTime)
        {
            Console.WriteLine("Customer is charged for Short Stay.");
            if(inTime.TimeOfDay < TimeSpan.FromHours(8) && outTime.TimeOfDay < TimeSpan.FromHours(8))
            {
                return 0.0;
            }
            else if(inTime.TimeOfDay > TimeSpan.FromHours(18) && outTime.TimeOfDay > TimeSpan.FromHours(18))
            {
                return 0.0;
            }
            else if(inTime.TimeOfDay >= TimeSpan.FromHours(8) && outTime.TimeOfDay <= TimeSpan.FromHours(18))
            {
                var duration = ((outTime - inTime).TotalMinutes)/60;
                return duration * 1.10;
            }
            else
            {

            }
            return 12.00;
        }
    }
}
