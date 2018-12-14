using CarRental.Domain;
using System.Collections.Generic;
using System.Linq;
using CarRental.Data;
using System.Net.Mail;
using System;

namespace CarRental.BusinessLogic
{
    public class CustomerMethods
    {
        public Repository Repos { get; }

        public CustomerMethods() : this(new Repository())
        {
        }

        public CustomerMethods(Repository newRepos)
        {
            Repos = newRepos;
        }

        public Customer GetAt(int id)
        {
            try
            {
                Customer customer = Repos.FindBy<Customer>(c => c.Id == id).First();

                return customer.DeepCopy();
            }
            catch (InvalidOperationException ex)
            {
                throw new IndexOutOfRangeException("Customer with select index, doesn't exist!");
            }
        }

        public Customer GetAt(string email)
        {
            try
            {
                Customer customer = Repos.FindBy<Customer>(c => c.Email == email).First();

                return customer.DeepCopy();
            }
            catch (InvalidOperationException ex)
            {
                throw new IndexOutOfRangeException("Customer with select email, doesn't exist!");
            }
        }

        public List<Customer> GetAll()
        {
            return Repos.DataSet<Customer>().ToList();
        }

        public Customer Add(Customer customer)
        {
            Validate(customer);

            Repos.Add<Customer>(customer.DeepCopy());
            Repos.SaveChanges();

            return customer;
        }

        public Customer Update(Customer customer)
        {
            Validate(customer);

            Repos.Edit<Customer>(customer.DeepCopy());
            Repos.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            Customer c = GetAt(id);
            Repos.Remove<Customer>(c);
            Repos.SaveChanges();
        }

        private void Validate(Customer customer)
        {
            List<string> messages = new List<string>();

            if (customer.FirstName.Length < 2)
            {
                messages.Add("First name need to be atleast 2 char long!");
            }

            if (customer.LastName.Length < 2)
            {
                messages.Add("Last name need to be atleast 2 char long!");
            }

            if (customer.PhoneNumber.Length < 5)
            {
                messages.Add("Phone number need to be atleast 5 number long!");
            }

            MailAddress email = new MailAddress(customer.Email);

            if (email.Address != customer.Email)
            {
                messages.Add("Email is not valid!");
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
