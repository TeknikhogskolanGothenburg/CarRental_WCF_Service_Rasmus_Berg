using CarRental.Data;
using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CarRental.BusinessLogic
{
    public class CarMethods
    {
        public Repository Repos { get; }

        public CarMethods() : this(new Repository())
        {
        }

        public CarMethods(Repository newRepos)
        {
            Repos = newRepos;
        }

        public Car GetAt(int id)
        {
            try
            {
                Car car = Repos.FindBy<Car>(c => c.Id == id && !c.Deleted).First();

                return car.DeepCopy();
            }
            catch(InvalidOperationException ex)
            {
                throw new IndexOutOfRangeException("Car with select index, doesn't exist!");
            }
        }

        public List<Car> GetAll()
        {
            return Repos.FindBy<Car>(c => !c.Deleted).ToList();
        }

        /// <summary>
        /// List of bookings during specified time interval.
        /// </summary>
        /// <param name="StartTime">Date when rental should start</param>
        /// <param name="EndTime">Date when rental will end</param>
        /// <returns>List of availble car between dates</returns>
        public List<Car> ListAvailable(DateTime StartTime, DateTime EndTime)
        {
            List<Booking> bookings = Repos.Context.Bookings
                .Include(b => b.BookingCar)
                .Where(b => ((b.StartTime <= EndTime && b.EndTime >= StartTime)))
                .ToList();

            List<Car> notAvailableCars = new List<Car>();

            foreach (Booking b in bookings)
            {
                notAvailableCars.Add(b.BookingCar);
            }

            return Repos.FindBy<Car>(c => !notAvailableCars.Any(car => car.Id == c.Id) && !c.Deleted).ToList();
        }

        public Car Add(Car car)
        {
            car.RegistrationNo = car.RegistrationNo.Trim();
            car.Available = true;

            Validate(car);

            Repos.Add<Car>(car.DeepCopy());
            Repos.SaveChanges();

            return car;
        }

        public void Delete(int id)
        {
            Car car = Repos.FindBy<Car>(c => c.Id == id).FirstOrDefault();

            if (car != null)
            {
                car.Deleted = true;
                Repos.Edit<Car>(car);
                Repos.SaveChanges();
            }
        }

        public Car PickUp(int id)
        {
            Car car = Repos.FindBy<Car>(c => c.Id == id && !c.Deleted).FirstOrDefault();

            if (car == null || !car.Available)
            {
                throw new Exception("Car is not available");
            }

            car.Available = false;
            Repos.Edit<Car>(car);
            Repos.SaveChanges();
            return car;
        }

        public Car DropOff(int id)
        {
            Car car = Repos.FindBy<Car>(c => c.Id == id).FirstOrDefault();

            if (car != null)
            {
                car.Available = true;
                Repos.Edit<Car>(car);
                Repos.SaveChanges();
            }

            return car;
        }

        private void Validate(Car car)
        {
            List<string> messages = new List<string>();

            Regex reg = new Regex("^[A-Za-zÅÄÖåäö]{3}[0-9]{3}$");

            if (reg.Matches(car.RegistrationNo).Count == 0)
            {
                messages.Add("Registration number are not valid, recheck it!");
            }

            if (car.Brand.Length < 2)
            {
                messages.Add("Brand need to be atleast 2 char long!");
            }

            if (car.Model.Length < 2)
            {
                messages.Add("Model need to be atleast 2 char long!");
            }

            if (car.ManufacturingYear < 1801)
            {
                messages.Add("Manufactory year could not be before first car for trafic was made!");
            }

            if (messages.Count > 0)
            {
                string msgs = "";

                foreach (string message in messages)
                {
                    msgs += message + "\n";
                }

                throw new FormatException(msgs);
            }
        }
    }
}
