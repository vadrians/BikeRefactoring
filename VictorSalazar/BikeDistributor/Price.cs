using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    public class PriceOrder
    {
        public double SubTotal { get; set; }
        public double Tax => SubTotal* Constants.TaxRate;
        public double Total => SubTotal + Tax;
    }
}
