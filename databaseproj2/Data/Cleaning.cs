using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Cleaning
{
    public int Id { get; set; }

    public DateOnly Datecleaned { get; set; }

    public int Staffid { get; set; }

    public int Roomid { get; set; }

    public bool? Foroccupancy { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
