using CustomerProductAPIs.Models;
using CustomerProductAPIs.Properties.Repo;
using System.Data;

namespace CustomerProductAPIs.Libraries
{
    public class ProductsLibrary : IproductsLibrary
    {
        private readonly IqueryDB _db;
        private readonly string tableName = "Products";
        public ProductsLibrary(IqueryDB db)
        {
            _db = db;
        }
        public Product addNewProduct(Product prod)
        {
            //prodName = '" + prod.ProdName + "', prodPrice = '" + prod.ProdPrice + "', prodBrand = '" + prod.ProdBrand + "' where ProductId = '" + id + "'"
            string query = tableName + " (prodName, prodPrice, prodBrand) VALUES( " +
               "'" + prod.ProdName + "', '" + prod.ProdPrice + "', '" + prod.ProdBrand + "'  )";
            string response = _db.EditDatabase(0, query);
            if (response!="1")
                return null;
            return prod;
        }

        public string deleteProductatId(int id)
        {
            Product old = GetSingleProductbyId(id);
            if (old == null)
                return "0";
            string query = tableName + " WHERE ProductId = " + id;
            string response = _db.EditDatabase(1, query);
            if (response != "1")
                return response;
            return response;
        }

        public List<Product> getProductsList()
        {
            DataSet ResponseData = _db.GetcustomerData(tableName);
            if (ResponseData == null)
                return null;
            List<Product> products = new List<Product>();
            int rows = ResponseData.Tables[0].Rows.Count;
            for (int i = 0; i < ResponseData.Tables[0].Rows.Count; i++)
            {
                Product prod = new Product();
                prod.ProductId = Convert.ToInt32(ResponseData.Tables[0].Rows[i]["ProductId"]);
                prod.ProdName = ResponseData.Tables[0].Rows[i]["prodName"].ToString();
                prod.ProdPrice = Convert.ToInt32(ResponseData.Tables[0].Rows[i]["prodPrice"]);
                prod.ProdBrand = ResponseData.Tables[0].Rows[i]["prodBrand"].ToString();
                products.Add(prod);
            }
            return products;
        }

        public Product GetSingleProductbyId(int id)
        {
            string where = tableName + " WHERE ProductId = " + id;
            DataSet ResponseData = _db.GetcustomerData(where);
            if (ResponseData.Tables[0].Rows.Count == 0)
                return null;
            Product prod = new Product();
            prod.ProductId = Convert.ToInt32(ResponseData.Tables[0].Rows[0]["ProductId"]);
            prod.ProdName = ResponseData.Tables[0].Rows[0]["prodName"].ToString();
            prod.ProdPrice = Convert.ToInt32(ResponseData.Tables[0].Rows[0]["prodPrice"]);
            prod.ProdBrand = ResponseData.Tables[0].Rows[0]["prodBrand"].ToString();
            return prod;
        }

        public string updateExistingProduct(int id, Product product)
        {
            Product old = GetSingleProductbyId(id);
            if (old == null)
                return "Record does not Exist";
            if (product.ProdName != null)
                old.ProdName = product.ProdName;
            if (product.ProdBrand != null)
                old.ProdBrand = product.ProdBrand;
            if (product.ProdPrice != null)
                old.ProdPrice = product.ProdPrice;
            string q = tableName + " set prodName = '" + old.ProdName + "', prodBrand = '" + old.ProdBrand + "', ProdPrice = '" + old.ProdPrice + "'";
            string where = " where ProductId = " + id;
            q += where;
            string response = _db.EditDatabase(2,q);
            if (response != "1")
                return response;
            return response;
        }
    }
}
