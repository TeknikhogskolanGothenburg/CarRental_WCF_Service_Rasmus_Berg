using CarRental.Data;
using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CarRental.BusinessLogic
{
    public class BookingMethods
    {
        public Repository Repos { get; }

        public BookingMethods() : this(new Repository())
        {
        }

        public BookingMethods(Repository newRepos)
        {
            Repos = newRepos;
        }

        public Booking GetAt(int id)
        {
            try
            {
                Booking booking = Repos.FindBy<Booking>(b => b.Id == id).First();

                return booking.DeepCopy();
            }
            catch (InvalidOperationException ex)
            {
                throw new IndexOutOfRangeException("Booking with select index, doesn't exist!");
            }
        }

        public List<Booking> GetBookingMadeByCustomer(int customerId)
        {
            if (customerId <= 0)
            {
                throw new IndexOutOfRangeException("Customer id are not valid, you need to pick an existing customer!");
            }

            List<Booking> bookings;
            bookings = Repos.FindBy<Booking>(b => b.CustomerId == customerId).ToList();

            return bookings;
        }

        public List<Booking> GetAll()
        {
            List<Booking> bookings;
            bookings = Repos.Context.Bookings
                    .Include(b => b.BookingCar)
                    .Include(b => b.BookingCustomer)
                    .ToList();
            return bookings;
        }

        public Booking Add(Booking booking)
        {
            Validate(booking);

            Repos.Add<Booking>(booking.DeepCopy());
            Repos.SaveChanges();

            return booking;
        }

        public void Delete(int id)
        {
            Booking booking = GetAt(id);

            if(booking != null)
            {
                Repos.Remove<Booking>(booking);
                Repos.SaveChanges();
            }
        }

        private void Validate(Booking booking)
        {
            List<string> messages = new List<string>();

            if (booking.CustomerId <= 0)
            {
                messages.Add("Customer id are not valid, you need to pick an existing customer!");
            }

            if (booking.BookingCarId <= 0)
            {
                messages.Add("Car id are not vaild, you need to pick an existing car!");
            }

            if (booking.StartTime >= booking.EndTime)
            {
                messages.Add("Start time on booking cannot be after or equal with end time.");
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
