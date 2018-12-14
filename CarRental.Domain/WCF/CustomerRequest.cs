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
        WrapperName = "CustomerRequest",
        WrapperNamespace = "http://chibidesign.se/Customer"
    )]
    public class CustomerRequest : License
    {
        [MessageBodyMember(Order = 1, Namespace = "http://chibidesign.se/Customer")]
        public int CustomerId { get; set; }
    }
}
