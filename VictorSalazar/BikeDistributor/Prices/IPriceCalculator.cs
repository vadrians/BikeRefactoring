using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Prices
{
    public interface IPriceCalculator
    {
        double GetAmount(Line line);
    }
}
