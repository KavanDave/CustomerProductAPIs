
using CustomerProductAPIs.Libraries;
using CustomerProductAPIs.Models;
using Microsoft.AspNetCore.Mvc;


namespace CustomerProductAPIs.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly string dbname = "Products";
        private readonly IproductsLibrary _productLibrary;
        public ProductController(IproductsLibrary productLibrary)
        {
            _productLibrary = productLibrary;
        }
        [HttpGet]
        public ActionResult<List<Product>> getProducts()
        {
            List<Product> responseProducts = _productLibrary.getProductsList();
            if (responseProducts == null)
                return NotFound("Sorry! No Products Available Currently");
            return Ok(responseProducts);
        }
        [HttpPost]
        public ActionResult<Product> addProduct(Product product)
        {
            Product responseProduct = _productLibrary.addNewProduct(product);
            if (responseProduct == null)
                return BadRequest("Bad Request, Please Check Inputs");
            return Ok(product);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductbyid(int id)
        {
            Product product= _productLibrary.GetSingleProductbyId(id);
            if (product == null)
                return NotFound("Product does not exist");
            return Ok(product);
        }
        [HttpPut("{id}")]
        public ActionResult<String> updateProduct(int id, Product product)
        {
            string response = _productLibrary.updateExistingProduct(id, product);
            if (response != "1")
                return BadRequest(response);
            return Ok("Sucess!");
        }
        [HttpDelete("{id}")]
        public ActionResult<string> deleteProduct(int id)
        {
            string response = _productLibrary.deleteProductatId(id);
            if (response == "0")
                return NotFound("Product does not exist!");
            return Ok("Record Deleted Sucessfully");

        }
    }
}
