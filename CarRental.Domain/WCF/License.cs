using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace CarRental.Domain
{
    [KnownType(typeof(CarInfo))]
    [KnownType(typeof(CarRequest))]
    [KnownType(typeof(CustomerInfo))]
    [KnownType(typeof(CustomersInfo))]
    [KnownType(typeof(CustomerRequest))]
    [KnownType(typeof(BookingInfo))]
    [KnownType(typeof(BookingsInfo))]
    [KnownType(typeof(BookingRequest))]
    [MessageContract(
        //IsWrapped = true,
        WrapperName = "License",
        WrapperNamespace = "http://chibidesign.se/License"
    )]
    public class License
    {
        [MessageHeader(Namespace = "http://chibidesign.se/License")]
        public string LicenseKey { get; set; }
    }
}
