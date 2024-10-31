using CustomerProductAPIs.Models.ReqandRes;
using CustomerProductAPIs.Models;
using CustomerProductAPIs.Properties.Repo;

namespace CustomerProductAPIs.Libraries
{
    public class customerProd : IcustomerProd
    {
        private readonly IqueryDB _db;
        private readonly string dbname = "CustomerProd";
        public customerProd(IqueryDB db)
        {
            _db = db;
        }
        //public customerProd addNewCustomer(customerProd user)
        //{
        //    string where = dbname + " (customer_fname, customer_lname, customer_email, customer_pass) VALUES( " +
        //        "'" + user.CustomerFname + "', '" + user.CustomerLname + "', '" + user.CustomerEmail + "', '" + user.CustomerPass + "'  )";
        //    string response = _db.EditDatabase(0, where);
        //    if (response != "1")
        //        return null;
        //    return user;
        //}

        //public string deleteCustomeratId(int id)
        //{
        //    string where = dbname + " WHERE customer_id = " + id;
        //    string response = _db.EditDatabase(1, where);
        //    return response;
        //}

        //public List<customerProd> getcustomerProdsList()
        //{
        //    DataSet ResponseData = _db.GetcustomerData(dbname);
        //    if (ResponseData == null)
        //        return null;
        //    List<customerProd> customerProds = new List<customerProd>();
        //    int rows = ResponseData.Tables[0].Rows.Count;
        //    for (int i = 0; i < ResponseData.Tables[0].Rows.Count; i++)
        //    {
        //        customerProd purchase = new customerProd();
        //        //purchase. = Convert.ToInt32(ResponseData.Tables[0].Rows[i]["customer_id"]);
        //        //purchase.CustomerFname = ResponseData.Tables[0].Rows[i]["customer_fname"].ToString();
        //        //purchase.CustomerLname = ResponseData.Tables[0].Rows[i]["customer_lname"].ToString();
        //        //purchase.CustomerEmail = ResponseData.Tables[0].Rows[i]["customer_email"].ToString();
        //        //purchase.CustomerPass = ResponseData.Tables[0].Rows[i]["customer_pass"].ToString();
        //        //Customers.Add(customer);
        //    }
        //    return Customers;
        //}

        //public Customer GetSingleCustomerbyId(int id)
        //{
        //    string where = dbname + " WHERE customer_id = " + id;
        //    DataSet ResponseData = _db.GetcustomerData(where);
        //    if (ResponseData == null)
        //        return null;
        //    Customer purchase = new Customer();
        //    //customer.CustomerFname = ResponseData.Tables[0].Rows[0]["customer_fname"].ToString();
        //    //customer.CustomerLname = ResponseData.Tables[0].Rows[0]["customer_lname"].ToString();
        //    //customer.CustomerEmail = ResponseData.Tables[0].Rows[0]["customer_email"].ToString();
        //    //customer.CustomerId = Convert.ToInt32(ResponseData.Tables[0].Rows[0]["customer_id"]);
        //    //customer.CustomerPass = ResponseData.Tables[0].Rows[0]["customer_pass"].ToString();
        //    return customer;
        //}

        //public string updateExistingCustomer(int id, customerRequest customer)
        //{
        //    Customer old = GetSingleCustomerbyId(id);
        //    if (old == null)
        //        return "Record does not Exist";
        //    if (customer.CustomerFname != null)
        //        old.CustomerFname = customer.CustomerFname;
        //    if (customer.CustomerLname != null)
        //        old.CustomerLname = customer.CustomerLname;
        //    if (customer.CustomerEmail != null)
        //        old.CustomerEmail = customer.CustomerEmail;
        //    if (customer.CustomerPass != null)
        //        old.CustomerPass = customer.CustomerPass;
        //    //customer = _mapper.Map<Customer>(old);
        //    string q = dbname + " set customer_fname = '" + old.CustomerFname + "', customer_lname = '" + old.CustomerLname + "', customer_email = '" + old.CustomerEmail + "', customer_pass = '" + old.CustomerPass + "'";
        //    string where = " where customer_id = " + id;
        //    q += where;
        //    string response = _db.EditDatabase(2, q);
        //    return response;
        //}
    }
}
