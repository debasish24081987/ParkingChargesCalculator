using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingChargeCalculator
{
    public interface IParkingCharge
    {
        double CalculateParkingCharge(DateTime inTime, DateTime outTime);
    }
}
