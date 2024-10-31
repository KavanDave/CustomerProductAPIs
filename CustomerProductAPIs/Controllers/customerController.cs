using AutoMapper;
using CustomerProductAPIs.Libraries;
using CustomerProductAPIs.Models;
using CustomerProductAPIs.Models.ReqandRes;
using CustomerProductAPIs.Properties.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CustomerProductAPIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class customerController : Controller
    {
        private readonly IcustomerLibrary _customerLibrary;

        public customerController(IcustomerLibrary customerLibrary)
        {
            _customerLibrary = customerLibrary;
        }

        [HttpGet]
        public ActionResult<List<Customer>> getCustomers()
        {
            List<Customer> responseCustomers = _customerLibrary.getCustomersList();
            if (responseCustomers == null)
                return NotFound("There are no users available currently");
            return Ok(responseCustomers);
        }
        [HttpPost]
        public ActionResult<Customer> addCustomer(Customer user)
        {
            Customer responseCustomer = _customerLibrary.addNewCustomer(user);
            if (responseCustomer == null)
                return BadRequest(user);
            return Ok(user);
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerbyid(int id)
        {
            Customer customer = _customerLibrary.GetSingleCustomerbyId(id);
            if (customer == null)
                return BadRequest("User does not exist");
            return Ok(customer);
        }
        [HttpPut("{id}")]
        public ActionResult<String> updateCustomer(int id, customerRequest customer)
        {
            string response = _customerLibrary.updateExistingCustomer(id, customer);
            if(response != "1")
                return BadRequest(response);
            return Ok("Sucess!");
        }
        [HttpDelete("{id}")]
        public ActionResult<string> deleteCustomer(int id)
        {
            string response = _customerLibrary.deleteCustomeratId(id);
            if (response != "1")
                return BadRequest("User does not exist");
            return Ok("Record Deleted Sucessfully");

        }
    }
}
