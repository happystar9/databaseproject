using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Addionalfee
{
    public int Id { get; set; }

    public string Itemname { get; set; } = null!;

    public decimal Itemcost { get; set; }

    public string? Description { get; set; }

    public int Rentalid { get; set; }

    public virtual Rental Rental { get; set; } = null!;
}
