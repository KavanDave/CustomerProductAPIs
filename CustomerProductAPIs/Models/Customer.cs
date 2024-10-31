using System;
using System.Collections.Generic;

namespace CustomerProductAPIs.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFname { get; set; }

    public string CustomerLname { get; set; }

    public string CustomerEmail { get; set; }

    public string CustomerPass { get; set; }
}
