using BikeDistributor.Formats;
using BikeDistributor.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {        
        private readonly IList<Line> _lines = new List<Line>();
        private Dictionary<double, IPriceCalculator> _priceStrategy;

        public Order(string company)
        {
            Company = company;

            _priceStrategy = new Dictionary<double, IPriceCalculator>();
            _priceStrategy.Add(Bike.OneThousand, new PriceCalculatorOneThousand());
            _priceStrategy.Add(Bike.TwoThousand, new PriceCalculatorTwoThousand());
            _priceStrategy.Add(Bike.FiveThousand, new PriceCalculatorFiveThousand());
        }

        public string Company { get; private set; }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string GetReceipt(IFormatter format)
        {

            var priceOrder = new PriceOrder();
            var result = new StringBuilder();
            result.Append(format.Header.Replace("{{Company}}", Company));

            foreach (var line in _lines)
            {
                var amount = GetPrice(line);

                result.Append(format.Body
                    .Replace("{{Quantity}}", line.Quantity.ToString())
                    .Replace("{{Brand}}", line.Bike.Brand)
                    .Replace("{{Model}}", line.Bike.Model)
                    .Replace("{{Amount}}", amount.ToString("C")));

                priceOrder.SubTotal += amount;
            }

            result.Append(format.Footer
                .Replace("{{SubTotal}}", priceOrder.SubTotal.ToString("C"))
                .Replace("{{Tax}}", priceOrder.Tax.ToString("C"))
                .Replace("{{Total}}", priceOrder.Total.ToString("C")));

            return result.ToString();
        }             

        private double GetPrice(Line line)
        {
            if (_priceStrategy.Any(s => s.Key == line.Bike.Price))
            {
                return _priceStrategy[line.Bike.Price].GetAmount(line);
            }
            else
            {
                return line.Bike.Price * line.Quantity;
            }
        }

        [Obsolete("Please use GetReceipt(IFormatter formatter) instead.")]
        public object GetReceipt()
        {
            return GetReceipt(new ReceiptFormat()); //Decided to keep this function so I would not break the existing Test Methods
        }

        [Obsolete("Please use GetReceipt(IFormatter formatter) instead.")]
        public string HtmlReceipt()
        {
            return GetReceipt(new HtmlReceiptFormat()); //Decided to keep this function so I would not break the existing Test Methods
        }
    }
}
