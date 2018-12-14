using System;
using System.Runtime.Serialization;

namespace CarRental.Domain
{
    [DataContract(Namespace = "http://chibidesign.se/2018/10/30/Booking")]
    public class Booking
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public Customer BookingCustomer { get; set; }
        [DataMember(Order = 3)]
        public int CustomerId { get; set; }

        [DataMember(Order = 4)]
        public Car BookingCar { get; set; }
        [DataMember(Order = 5)]
        public int BookingCarId { get; set; }

        [DataMember(Order = 6)]
        public DateTime StartTime { get; set; }
        [DataMember(Order = 7)]
        public DateTime EndTime { get; set; }

        public Booking DeepCopy()
        {
            return new Booking
            {
                Id = this.Id,
                BookingCustomer = (this.BookingCustomer != null) ? this.BookingCustomer.DeepCopy() : null,
                CustomerId = this.CustomerId,
                BookingCar = (this.BookingCar != null) ? this.BookingCar.DeepCopy() : null,
                BookingCarId = this.BookingCarId,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };
        }
    }
}
