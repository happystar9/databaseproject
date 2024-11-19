using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Rentalroom
{
    public int Id { get; set; }

    public int Staffid { get; set; }

    public DateOnly? Checkoutdate { get; set; }

    public int Rentalid { get; set; }

    public decimal Nightlyprice { get; set; }

    public int Roomid { get; set; }

    public virtual Rental Rental { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
