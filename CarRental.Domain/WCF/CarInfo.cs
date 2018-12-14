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
        WrapperName = "CarInfo",
        WrapperNamespace = "http://chibidesign.se/Car"
    )]
    public class CarInfo : License
    {
        [MessageBodyMember(Namespace = "http://chibidesign.se/Car")]
        public Car Car { get; set; }

        public CarInfo()
        {
            Car = new Car();
        }

        public CarInfo(Car newCar)
        {
            Car = newCar.DeepCopy();
        }
    }
}
