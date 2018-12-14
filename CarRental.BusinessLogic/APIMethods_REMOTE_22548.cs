using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data;

namespace CarRental.BusinessLogic
{
    public class APIMethods
    {
        public Booking AddBooking (Booking booking)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking (int bookingId)
        {
            
        }

        public Customer AddCustomer (Customer customer)
        {
           throw new NotImplementedException();
        }

        public void DeleteCustomer (int customerId)
        {
           throw new NotImplementedException();
        }

        public Customer EditCustomer (Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Car> ListAvailableCars (DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public Car DropOffCar (int CarId)
        {
            throw new NotImplementedException();
        }

        public Car AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar (int carId)
        {
            throw new NotImplementedException();
        }
    }
}
