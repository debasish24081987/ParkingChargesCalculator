using System;

namespace ParkingChargeCalculator
{
    public abstract class AbstractParkingFactory
    {
        public abstract IParkingCharge GetParkingType(string type);
    }

    public class ConcreteParkingFactory : AbstractParkingFactory
    {
        public override IParkingCharge GetParkingType(string type)
        {
            switch (type)
            {
                case "Short Stay":
                    return new ShortStayCharge();
                case "Long Stay":
                    return new LongStayCharge();
                default:
                    throw new ApplicationException(string.Format("{0} : Invalid Parking Type", type));
            }
        }
    }
}
