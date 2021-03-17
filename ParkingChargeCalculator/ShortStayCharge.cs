using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingChargeCalculator
{
    public class ShortStayCharge : IParkingCharge
    {
        TimeSpan minTimeOfDay = TimeSpan.FromHours(8);
        TimeSpan maxTimeOfDay = TimeSpan.FromHours(18);
        double maxChargePerDay = 11.0;
        double totalCharges = 0.0;
        double perHourParkingCharge = 1.10;

        public double CalculateParkingCharge(DateTime inTime, DateTime outTime)
        {
            Console.WriteLine("Customer is charged for Short Stay.");

            if(inTime.TimeOfDay < minTimeOfDay && outTime.TimeOfDay < minTimeOfDay) // in time and out time before 8AM weekday
            {
                return 0.0;
            }
            else if(inTime.TimeOfDay > maxTimeOfDay && outTime.TimeOfDay > maxTimeOfDay) // in time and out time after 6PM weekday
            {
                return 0.0;
            }

            // in time and outime in the weekend
            if ((inTime.DayOfWeek == DayOfWeek.Saturday || inTime.DayOfWeek == DayOfWeek.Sunday) &&
                (outTime.DayOfWeek == DayOfWeek.Saturday || outTime.DayOfWeek == DayOfWeek.Sunday))
            {
                return 0.0;
            }
            else
            {
                if(inTime.Day == outTime.Day) // same day in time and out time
                {
                    if (inTime.TimeOfDay <= minTimeOfDay && outTime.TimeOfDay >= maxTimeOfDay)
                    {
                        return maxChargePerDay;
                    }
                    else
                    {
                        if (inTime.TimeOfDay >= minTimeOfDay && outTime.TimeOfDay <= maxTimeOfDay)
                        {
                            return (outTime - inTime).TotalHours * perHourParkingCharge;
                        }
                        else if(inTime.TimeOfDay <= minTimeOfDay && outTime.TimeOfDay <= maxTimeOfDay)
                        {
                            return (outTime.TimeOfDay - minTimeOfDay).TotalHours * perHourParkingCharge;
                        }
                        else if(inTime.TimeOfDay >= minTimeOfDay && outTime.TimeOfDay >= maxTimeOfDay)
                        {
                            return (maxTimeOfDay - inTime.TimeOfDay).TotalHours * perHourParkingCharge;
                        }
                    }
                }               
                else //multiple days
                {
                    var dates = new List<DateTime>();
                    for (var dt = inTime; dt <= outTime.AddHours(24 - outTime.Hour - 0.0001); dt = dt.AddDays(1))
                    {
                        dates.Add(dt);
                    }

                    foreach (var date in dates)
                    {
                        if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            totalCharges += 0.0;
                        }
                        else
                        {
                            if(dates.First() == date)
                            {
                                totalCharges += (maxTimeOfDay - inTime.TimeOfDay).TotalHours * perHourParkingCharge;
                            }
                            else if(dates.Last() == date)
                            {
                                totalCharges += (outTime.TimeOfDay - minTimeOfDay).TotalHours * perHourParkingCharge;
                            }
                            else
                            {
                                totalCharges += maxChargePerDay;
                            }
                        }
                    }
                }
            }
            return totalCharges;
        }
    }
}
