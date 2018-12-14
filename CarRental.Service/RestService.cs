using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain;
using CarRental.BusinessLogic;
using CarRental.Data;

namespace CarRental.Service
{
    public class RestService : IRestService
    {
        BookingMethods bookingMethods;
        CarMethods carMethods;
        CustomerMethods customerMethods;

        public RestService()
        {
            Repository repository = new Repository();
            bookingMethods = new BookingMethods(repository);
            carMethods = new CarMethods(repository);
            customerMethods = new CustomerMethods(repository);
        }

        public Customer AddCustomer(Customer customer)
        {
            return customerMethods.Add(customer);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return customerMethods.GetAt(email);
        }

        public Customer GetCustomerById(string id)
        {
            return customerMethods.GetAt(int.Parse(id));
        }

        public Customer EditCustomer(Customer customer)
        {
            return customerMethods.Update(customer);
        }

        public void DeleteCustomer(string id)
        {
            customerMethods.Delete(int.Parse(id));
        }

        public List<Car> GetAllCars()
        {
            return carMethods.GetAll();
        }

        public List<Car> GetAvailableCars(string dateFrom, string dateTo)
        {
            return carMethods.ListAvailable(DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
        }

        public Booking AddBooking(Booking booking)
        {
            return bookingMethods.Add(booking);
        }

        public List<Booking> GetBookings(string customerId)
        {
            return bookingMethods.GetBookingMadeByCustomer(int.Parse(customerId));
        }

        public void DeleteBooking(string id)
        {
            bookingMethods.Delete(int.Parse(id));
        }
    }
}
