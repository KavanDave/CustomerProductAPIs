using CustomerProductAPIs.Models.ReqandRes;
using CustomerProductAPIs.Models;

namespace CustomerProductAPIs.Libraries
{
    public interface IproductsLibrary
    {
        public List<Product> getProductsList();
        public Product addNewProduct(Product product);
        public Product GetSingleProductbyId(int id);
        public String updateExistingProduct(int id, Product product);
        public string deleteProductatId(int id);
    }
}
