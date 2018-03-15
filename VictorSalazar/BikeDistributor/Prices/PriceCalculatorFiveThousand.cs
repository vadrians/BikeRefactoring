using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Prices
{
    public class PriceCalculatorFiveThousand : IPriceCalculator
    {
        public double GetAmount(Line line)
        {
            if (line.Quantity >= 5)
                return line.Quantity * line.Bike.Price * Constants.FiveThousandDiscount;
            else
                return line.Quantity * line.Bike.Price;
        }
    }
}
