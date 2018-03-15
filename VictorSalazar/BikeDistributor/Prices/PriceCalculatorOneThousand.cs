using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Prices
{
    public class PriceCalculatorOneThousand : IPriceCalculator
    {
        public double GetAmount(Line line)
        {
            if (line.Quantity >= 20)
                return line.Quantity * line.Bike.Price * Constants.OneThousandDiscount;
            else
                return line.Quantity * line.Bike.Price;
        }
    }
}
