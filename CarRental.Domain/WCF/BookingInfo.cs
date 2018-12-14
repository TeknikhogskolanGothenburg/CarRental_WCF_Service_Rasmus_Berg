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
        WrapperName = "BookingInfo",
        WrapperNamespace = "http://chibidesign.se/Booking"
    )]
    public class BookingInfo : License
    {
        [MessageBodyMember(Order = 1, Namespace = "http://chibidesign.se/Booking")]
        public Booking Booking { get; set; }

        public BookingInfo()
        {
            Booking = new Booking();
        }

        public BookingInfo(Booking newBooking)
        {
            Booking = newBooking.DeepCopy();
        }
    }
}
