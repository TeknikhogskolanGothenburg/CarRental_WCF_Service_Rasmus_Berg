using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using CarRental.Domain;

namespace CarRental.Service
{
    [ServiceContract]
    public interface IRestService
    {
        [WebInvoke(
            Method = "POST",
            UriTemplate = "customers/",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare
        )]
        Customer AddCustomer(Customer customer);


        [WebGet(
            UriTemplate = "customers/email/{email}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
        )]
        Customer GetCustomerByEmail(string email);

        [WebGet(
            UriTemplate = "customers/id/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
        )]
        Customer GetCustomerById(string id);

        [WebInvoke(
            Method = "PUT",
            UriTemplate = "customers/",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
        )]
        Customer EditCustomer(Customer customer);

        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "customers/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped
        )]
        void DeleteCustomer(string id);

        [OperationContract]
        [WebGet(
            UriTemplate = "cars",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
        )]
        List<Car> GetAllCars();

        [OperationContract]
        [WebGet(
            UriTemplate = "cars/available/{dateFrom}/{dateTo}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
         )]
        List<Car> GetAvailableCars(string dateFrom, string dateTo);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "bookings/",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
         )]
        Booking AddBooking(Booking booking);

        [OperationContract]
        [WebGet(
            UriTemplate = "bookings/customer/{customerId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
         )]
        List<Booking> GetBookings(string customerId);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "bookings/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped
         )]
        void DeleteBooking(string id);
    }
}
