using CarRental.BusinessLogic;
using System;
using System.Collections.Generic;
using CarRental.Domain;
using CarRental.Data;
using System.ServiceModel.Web;
using System.Net;

namespace CarRental.Service
{
    public class CarRentalService : ICarService, ICustomerService, IBookingService
    {
        private Repository repository;
        private BookingMethods bookingMethods;
        private CarMethods carMethods;
        private CustomerMethods customerMethods;

        public CarRentalService()
        {
            repository = new Repository();
            bookingMethods = new BookingMethods(repository);
            carMethods = new CarMethods(repository);
            customerMethods = new CustomerMethods(repository);
        }

        private void LicenseCheck(string licenseKey, int accessGrade = 0)
        {
            if (licenseKey != "Admin123" && (licenseKey != "CustomerLicense123" || accessGrade > 0))
            {
                throw new WebFaultException<string>("Wrong license key", HttpStatusCode.Forbidden);
            }
        }

        // *****************
        // ** Car methods **
        // *****************

        public Car GetCarAt(int id)
        {
            return carMethods.GetAt(id);
        }

        public List<Car> GetAllCars()
        {
            return carMethods.GetAll();
        }

        public List<Car> ListAvailableCars(DateTime StartTime, DateTime EndTime)
        {
            return carMethods.ListAvailable(StartTime, EndTime);
        }

        public CarInfo AddCar(CarInfo carInfo)
        {
            LicenseCheck(carInfo.LicenseKey, 1);

            CarInfo addedCarInfo = new CarInfo(carMethods.Add(carInfo.Car));
            carInfo.LicenseKey = carInfo.LicenseKey;

            return addedCarInfo;
        }

        public CarInfo PickUpCar(CarRequest request)
        {
            LicenseCheck(request.LicenseKey, 1);

            CarInfo carInfo = new CarInfo(carMethods.PickUp(request.CarId));
            carInfo.LicenseKey = request.LicenseKey;

            return carInfo;
        }

        public CarInfo DropOffCar(CarRequest request)
        {
            LicenseCheck(request.LicenseKey, 1);

            CarInfo carInfo = new CarInfo(carMethods.DropOff(request.CarId));
            carInfo.LicenseKey = request.LicenseKey;

            return carInfo;
        }

        public StatusResponse DeleteCar(CarRequest request)
        {
            LicenseCheck(request.LicenseKey, 1);

            StatusResponse response = new StatusResponse();
            response.LicenseKey = request.LicenseKey;

            try
            {
                carMethods.Delete(request.CarId);
                response.Status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.Status = false;
            }

            return response;
        }

        // **********************
        // ** Customer methods **
        // **********************

        public CustomerInfo GetCustomerAt(CustomerRequest request)
        {
            LicenseCheck(request.LicenseKey);

            CustomerInfo customerInfo = new CustomerInfo(customerMethods.GetAt(request.CustomerId));
            customerInfo.LicenseKey = request.LicenseKey;

            return customerInfo;
        }

        public CustomersInfo GetAllCustomers(License license)
        {
            LicenseCheck(license.LicenseKey, 1);

            CustomersInfo customersInfo = new CustomersInfo(customerMethods.GetAll());
            customersInfo.LicenseKey = license.LicenseKey;

            return customersInfo;
        }

        public Customer AddCustomer(Customer customer)
        {
            return customerMethods.Add(customer);
        }

        public CustomerInfo UpdateCustomer(CustomerInfo customerInfo)
        {
            LicenseCheck(customerInfo.LicenseKey);

            CustomerInfo addedCustomerInfo = new CustomerInfo(customerMethods.Update(customerInfo.Customer));
            addedCustomerInfo.LicenseKey = customerInfo.LicenseKey;

            return addedCustomerInfo;
        }

        public StatusResponse DeleteCustomer(CustomerRequest request)
        {
            LicenseCheck(request.LicenseKey);

            StatusResponse response = new StatusResponse();
            response.LicenseKey = request.LicenseKey;

            try
            {
                customerMethods.Delete(request.CustomerId);
                response.Status = true;
            }
            catch
            {
                response.Status = false;
            }

            return response;
        }

        // *********************
        // ** Booking methods **
        // *********************

        public BookingInfo GetBookingAt(BookingRequest request)
        {
            LicenseCheck(request.LicenseKey);

            BookingInfo bookingInfo = new BookingInfo(bookingMethods.GetAt(request.BookingId));
            bookingInfo.LicenseKey = request.LicenseKey;

            return bookingInfo;
        }

        public BookingsInfo GetAllBookings(License license)
        {
            LicenseCheck(license.LicenseKey);

            BookingsInfo bookingsInfo = new BookingsInfo(bookingMethods.GetAll());

            return bookingsInfo;
        }

        public BookingInfo AddBooking(BookingInfo bookingInfo)
        {
            LicenseCheck(bookingInfo.LicenseKey);

            BookingInfo addedBookingInfo = new BookingInfo(bookingMethods.Add(bookingInfo.Booking));

            return addedBookingInfo;
        }

        public StatusResponse DeleteBooking(BookingRequest request)
        {
            LicenseCheck(request.LicenseKey);

            StatusResponse response = new StatusResponse();
            response.LicenseKey = request.LicenseKey;

            try
            {
                bookingMethods.Delete(request.BookingId);
                response.Status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.Status = false;
            }

            return response;
        }
    }
}
