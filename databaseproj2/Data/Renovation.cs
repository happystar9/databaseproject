using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Renovation
{
    public int Id { get; set; }

    public int Room { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public string? Description { get; set; }

    public virtual Room RoomNavigation { get; set; } = null!;
}
