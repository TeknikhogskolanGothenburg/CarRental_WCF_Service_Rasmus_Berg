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
        public Repository repos = new Repository();
        public void AddBooking (Booking booking)
        {
           repos.Add<Booking>(booking);
            repos.SaveChanges();
        }

        public void DeleteBooking (int bookingId)
        {
            Booking b = repos.FindBy<Booking>(book => book.Id == bookingId).FirstOrDefault();
            repos.Remove<Booking>(b);
            repos.SaveChanges();

        }

        public void AddCustomer (Customer customer)
        {
            repos.Add<Customer>(customer);
            repos.SaveChanges();
        }

        public void DeleteCustomer (int customerId)
        {
            Customer c = repos.FindBy<Customer>(cust => cust.Id == customerId).FirstOrDefault();
            repos.Remove<Customer>(c);
            repos.SaveChanges();
        }

        public Customer EditCustomer (Customer customer)
        {
            repos.Edit<Customer>(customer);
            repos.SaveChanges();
            return customer;
        }

        public List<Car> ListAvailableCars (DateTime dateFrom, DateTime dateTo)
        {
            //List of bookings during specified time interval.
            List<Booking> bookings = repos.FindBy<Booking>(b => b.StartTime >= dateFrom && b.EndTime <= dateTo).ToList();
            List<Car> notAvailableCars = new List<Car>();
            foreach(Booking b in bookings)
            {
                foreach(BookingCar bc in b.BookingCars)
                {
                    notAvailableCars.Add(bc.Car);
                }
            }
            repos.SaveChanges();
            return repos.FindBy<Car>(c=> !notAvailableCars.Any(car => car.Id == c.Id)).ToList();          
        }

        public Car DropOffCar (int carId)
        {
            Car c = repos.FindBy<Car>(car => car.Id == carId).FirstOrDefault();
            c.Available = true;
            repos.Edit<Car>(c);
            repos.SaveChanges();
            return c;
        }

        public Car PickUpCar (int carId)
        {
            Car c = repos.FindBy<Car>(car => car.Id == carId).FirstOrDefault();
            c.Available = false;
            repos.Edit<Car>(c);
            repos.SaveChanges();
            return c;
        }
        public void AddCar(Car car)
        {
            repos.Add<Car>(car);
            repos.SaveChanges();
        }

        public void DeleteCar (int carId)
        {
            Car c = repos.FindBy<Car>(car => car.Id == carId).FirstOrDefault();
            c.Deleted = true;
            repos.Edit<Car>(c);
            repos.SaveChanges();
        }

        public Car GetCar (int carId)
        {
            return repos.FindBy<Car>(c => c.Id == carId).FirstOrDefault();
        }
        public Customer GetCustomer(int customerId)
        {
            return repos.FindBy<Customer>(c => c.Id == customerId).FirstOrDefault();
        }

        public Booking GetBooking(int bookingId)
        {
            return repos.FindBy<Booking>(b => b.Id == bookingId).FirstOrDefault();
        }
        public List<Car> GetCars()
        {
            return repos.DataSet<Car>().ToList();
        }
        public List<Customer> GetCustomer()
        {
            return repos.DataSet<Customer>().ToList();
        }

        public List<Booking> GetBookings()
        {
            return repos.DataSet<Booking>().ToList();
        }

    }
}
