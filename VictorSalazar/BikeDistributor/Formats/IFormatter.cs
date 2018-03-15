using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Formats
{
    public interface IFormatter
    {
        string Header { get;  }
        string Body { get; }
        string Footer { get; }
    }
}
