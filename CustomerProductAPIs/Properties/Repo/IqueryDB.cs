using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Data;
using System.Data.SqlClient;

namespace CustomerProductAPIs.Properties.Repo
{
    public interface IqueryDB
    {
        //bool InsertCustomerData(string q);
        //string DeleteRecord(string q);
        //string UpdateRecord(string q);
        string EditDatabase(int Operation, string q);
        DataSet GetcustomerData(string q);

    }
}
