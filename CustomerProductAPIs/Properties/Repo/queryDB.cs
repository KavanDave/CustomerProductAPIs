using CustomerProductAPIs.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Data;
using System.Data.SqlClient;

namespace CustomerProductAPIs.Properties.Repo
{
    public class queryDB: IqueryDB
    {
        private string Constr = @"Data Source=LAPTOP-BQRQRJNL\SQLEXPRESS;Initial Catalog=newCustomerProd;Integrated Security=True;Encrypt=False";
        public string EditDatabase(int Operation, string q)
        {
            string command = string.Empty;
            switch (Operation)
            {
                case 0:
                    command = "INSERT INTO ";
                    break;
                case 1:
                    command = "DELETE FROM ";
                    break;
                case 2:
                    command = "UPDATE ";
                    break;
                default:
                    break;
            }
            try
            {
                command += q;
                SqlConnection conn = new SqlConnection(Constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "1";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public DataSet GetcustomerData(string end)
        {
            try
            {
                string q = "SELECT * FROM " + end;
                SqlConnection Conn = new SqlConnection(Constr);
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = q;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet customers = new DataSet();
                adapter.Fill(customers);
                Conn.Close();
                return customers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}
//        public bool InsertCustomerData(string query)
//        {
//            try
//            {
//                //string q = "INSERT INTO " + where;
//                SqlConnection Conn = new SqlConnection(Constr);
//                Conn.Open();
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = Conn;
//                cmd.CommandText = query;
//                cmd.ExecuteNonQuery();
//                Conn.Close();
//                return true;
//;            }
//            catch(Exception e) 
//            {
//                return false;
//            }

//        }
//        public string DeleteRecord(string query)
//        {
//            try
//            {
//                //string query = "delete from " + where;
//                SqlConnection conn = new SqlConnection(Constr);
//                conn.Open();
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = conn;
//                cmd.CommandText = query;
//                cmd.ExecuteNonQuery();
//                conn.Close();
//                return null;
//            }
//            catch (Exception e)
//            {
//                return e.ToString();
//            }
//        }
//        public string UpdateRecord(string where)
//        {
//            try
//            {
//                string q = "update " + where;
//                SqlConnection conn = new SqlConnection(Constr);
//                conn.Open();
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = conn;
//                cmd.CommandText = q;
//                cmd.ExecuteNonQuery();
//                conn.Close();
//                return "1";
//            }
//            catch (Exception e)
//            {
//                return e.ToString();
//            }
//        }