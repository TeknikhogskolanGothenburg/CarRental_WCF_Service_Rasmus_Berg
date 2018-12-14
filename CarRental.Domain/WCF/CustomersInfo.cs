using System.Collections.Generic;
using System.ServiceModel;

namespace CarRental.Domain
{
    [MessageContract(
        IsWrapped = true,
        WrapperName = "CustomersInfo",
        WrapperNamespace = "http://chibidesign.se/Customer"
    )]
    public class CustomersInfo : License
    {
        [MessageBodyMember(Namespace = "http://chibidesign.se/Customer")]
        public List<Customer> Customers { get; set; }

        public CustomersInfo() : this(new List<Customer>())
        {
        }

        public CustomersInfo(List<Customer> newCustomers)
        {
            Customers = new List<Customer>();

            foreach (Customer Customer in newCustomers)
            {
                Customers.Add(Customer.DeepCopy());
            }
        }
    }
}