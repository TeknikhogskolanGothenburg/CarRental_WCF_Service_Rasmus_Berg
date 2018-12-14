using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CarRental.Domain
{
    [DataContract(Namespace = "http://chibidesign.se/2018/11/21/Customer")]
    public class Customer
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [DataMember(Order = 4)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 5)]
        public string Email { get; set; }

        public Customer DeepCopy()
        {
            return new Customer
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber
            };
        }
    }
}
