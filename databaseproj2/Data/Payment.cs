using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Payment
{
    public int Id { get; set; }

    public int Rentalid { get; set; }

    public int Staffid { get; set; }

    public decimal Amountpaid { get; set; }

    public DateOnly? Paymentdate { get; set; }

    public virtual Rental Rental { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
