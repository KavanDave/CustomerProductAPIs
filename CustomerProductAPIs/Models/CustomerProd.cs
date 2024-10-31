using System;
using System.Collections.Generic;

namespace CustomerProductAPIs.Models;

public partial class CustomerProd
{
    public int CustomerProdId { get; set; }

    public int? ProdidFk { get; set; }

    public int? CustomeridFk { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public string TypeofPayment { get; set; }

    public virtual Product ProdidFkNavigation { get; set; }
}
