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
        WrapperName = "BookingsInfo",
        WrapperNamespace = "http://chibidesign.se/Booking"
    )]
    public class BookingsInfo : License
    {
        [MessageBodyMember(Namespace = "http://chibidesign.se/Booking")]
        public List<Booking> Bookings { get; set; }

        public BookingsInfo() : this(new List<Booking>())
        {
        }

        public BookingsInfo(List<Booking> newBookings)
        {
            Bookings = new List<Booking>();

            foreach (Booking booking in newBookings)
            {
                Bookings.Add(booking.DeepCopy());
            }
        }
    }
}
