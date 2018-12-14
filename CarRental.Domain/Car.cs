using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CarRental.Domain
{
    [DataContract(Namespace = "http://chibidesign.se/2018/11/21/Car")]
    public class Car
    {
        private bool available;
        private bool deleted;

        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string RegistrationNo { get; set; }

        [DataMember(Order = 3)]
        public string Brand { get; set; }

        [DataMember(Order = 4)]
        public string Model { get; set; }

        [DataMember(Order = 5)]
        public int ManufacturingYear { get; set; }

        [DataMember(Order = 7)]
        public bool Available {
            get
            {
                return available;
            }
            set
            {
                available = value;
            }
        }

        [DataMember(Order = 8)]
        public bool Deleted
        {
            get
            {
                return deleted;
            }
            set
            {
                deleted = value;
            }
        }

        public Car ()
        {
            available = true;
            deleted = false;
        }

        public Car DeepCopy()
        {
            return new Car
            {
                Id = this.Id,
                RegistrationNo = this.RegistrationNo,
                Brand = this.Brand,
                Model = this.Model,
                ManufacturingYear = this.ManufacturingYear,
                Available = this.Available,
                Deleted = this.Deleted
            };
        }
    }
}
