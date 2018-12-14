using System.Net.Security;
using System.ServiceModel;
using CarRental.Domain;

namespace CarRental.Service
{
    [ServiceContract]
    interface ICustomerService
    {
        [OperationContract(Name = "GetAt", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        CustomerInfo GetCustomerAt(CustomerRequest request);

        [OperationContract(Name = "GetAll", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        CustomersInfo GetAllCustomers(License license);

        [OperationContract(Name = "Add")]
        Customer AddCustomer(Customer customer);

        [OperationContract(Name = "Update", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        CustomerInfo UpdateCustomer(CustomerInfo customerInfo);

        [OperationContract(Name = "Delete", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        StatusResponse DeleteCustomer(CustomerRequest request);
    }
}
