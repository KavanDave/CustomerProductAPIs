using System;
using System.Collections.Generic;

namespace CustomerProductAPIs.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProdName { get; set; }

    public decimal? ProdPrice { get; set; }

    public string ProdBrand { get; set; }

    public virtual ICollection<CustomerProd> CustomerProds { get; set; } = new List<CustomerProd>();
}
