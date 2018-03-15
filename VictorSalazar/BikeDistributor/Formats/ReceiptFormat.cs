using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Formats
{
    public class ReceiptFormat : IFormatter
    {
        public string Header => "Order Receipt for {{Company}}" + Environment.NewLine;

        public string Body => "\t{{Quantity}} x {{Brand}} {{Model}} = {{Amount}}" + Environment.NewLine;

        public string Footer
        {

            get
            {
                var footer = new StringBuilder();
                footer.AppendLine("Sub-Total: {{SubTotal}}");
                footer.AppendLine("Tax: {{Tax}}");
                footer.Append("Total: {{Total}}");
                return footer.ToString();
            }
        }
    }
}
