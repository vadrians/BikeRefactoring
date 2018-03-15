using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Prices
{
    public class PriceCalculatorTwoThousand : IPriceCalculator
    {
        public double GetAmount(Line line)
        {
            if (line.Quantity >= 10)
                return line.Quantity * line.Bike.Price * Constants.TwoThousandDiscount;
            else
                return line.Quantity * line.Bike.Price;
        }
    }
}
