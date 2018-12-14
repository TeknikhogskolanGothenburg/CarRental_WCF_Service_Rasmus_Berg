using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using CarRental.Domain;

namespace CarRental.Service
{
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract(Name = "Add", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        CarInfo AddCar(CarInfo carInfo);

        [OperationContract(Name = "GetAt")]
        Car GetCarAt(int id);

        [OperationContract(Name = "GetAll")]
        List<Car> GetAllCars();

        [OperationContract(Name = "ListAvailable")]
        List<Car> ListAvailableCars(DateTime startTime, DateTime endTime);

        [OperationContract(Name = "Delete", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        StatusResponse DeleteCar(CarRequest request);

        [OperationContract(Name = "PickUp", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        CarInfo PickUpCar(CarRequest request);

        [OperationContract(Name = "DropOff", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        CarInfo DropOffCar(CarRequest request);
    }
}
