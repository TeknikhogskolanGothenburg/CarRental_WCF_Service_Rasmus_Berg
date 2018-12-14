using System.Net.Security;
using System.ServiceModel;
using CarRental.Domain;

namespace CarRental.Service
{
    [ServiceContract]
    interface IBookingService
    {
        [OperationContract(Name = "GetAt", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        BookingInfo GetBookingAt(BookingRequest request);

        [OperationContract(Name = "GetAll", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        BookingsInfo GetAllBookings(License license);

        [OperationContract(Name = "Add", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        BookingInfo AddBooking(BookingInfo bookingInfo);

        [OperationContract(Name = "Delete", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        StatusResponse DeleteBooking(BookingRequest request);
    }
}
