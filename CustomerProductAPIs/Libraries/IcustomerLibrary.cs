using CustomerProductAPIs.Models;
using CustomerProductAPIs.Models.ReqandRes;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProductAPIs.Libraries
{
    public interface IcustomerLibrary
    {
        public List<Customer> getCustomersList();
        public Customer addNewCustomer(Customer user);
        public Customer GetSingleCustomerbyId(int id);
        public String updateExistingCustomer(int id, customerRequest customer);
        public string deleteCustomeratId(int id);
    }
}
