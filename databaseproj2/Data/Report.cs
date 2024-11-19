using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Report
{
    public int Id { get; set; }

    public decimal? Revenue { get; set; }

    public double? Occupancy { get; set; }

    public DateOnly Reportddate { get; set; }
}
