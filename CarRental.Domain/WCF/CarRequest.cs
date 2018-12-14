using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    [MessageContract(
        IsWrapped = true,
        WrapperName = "CarRequest",
        WrapperNamespace = "http://chibidesign.se/Car"
    )]
    public class CarRequest : License
    {
        [MessageBodyMember(Namespace = "http://chibidesign.se/Car")]
        public int CarId { get; set; }
    }
}
