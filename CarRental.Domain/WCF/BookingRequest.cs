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
        WrapperName = "BookingRequest",
        WrapperNamespace = "http://chibidesign.se/Booking"
    )]
    public class BookingRequest : License
    {
        [MessageBodyMember(Order = 1, Namespace = "http://chibidesign.se/Booking")]
        public int BookingId { get; set; }
    }
}