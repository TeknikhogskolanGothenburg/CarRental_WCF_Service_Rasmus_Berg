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
        WrapperName = "CustomerInfo",
        WrapperNamespace = "http://chibidesign.se/Customer"
    )]
    public class CustomerInfo : License
    {
        [MessageBodyMember(Namespace = "http://chibidesign.se/Customer")]
        public Customer Customer { get; set; }

        public CustomerInfo()
        {
            Customer = new Customer();
        }

        public CustomerInfo(Customer newCustomer)
        {
            Customer = newCustomer.DeepCopy();
        }
    }
}
