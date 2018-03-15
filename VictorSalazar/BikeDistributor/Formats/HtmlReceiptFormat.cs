using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Formats
{
    public class HtmlReceiptFormat : IFormatter
    {
        public string Header => "<html><body><h1>Order Receipt for {{Company}}</h1><ul>";
        public string Body => "<li>{{Quantity}} x {{Brand}} {{Model}} = {{Amount}}</li>";
        public string Footer
        {
            get {
                var footer = new StringBuilder();
                footer.Append("</ul>");
                footer.Append("<h3>Sub-Total: {{SubTotal}}</h3>");
                footer.Append("<h3>Tax: {{Tax}}</h3>");
                footer.Append("<h2>Total: {{Total}}</h2>");
                footer.Append("</body></html>");
                return footer.ToString();
            }

        }


    }
}
