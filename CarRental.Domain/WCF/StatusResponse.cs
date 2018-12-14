using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CarRental.Domain
{
    [MessageContract(
        IsWrapped = true,
        WrapperName = "StatusResponse",
        WrapperNamespace = "http://chibidesign.se/StatusResponse"
    )]
    public class StatusResponse : License
    {
        public bool Status { get; set; }
    }
}
