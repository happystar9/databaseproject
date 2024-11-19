using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Room
{
    public int Id { get; set; }

    public string? Roomnumber { get; set; }

    public int? Roomtypeid { get; set; }

    public virtual ICollection<Cleaning> Cleanings { get; set; } = new List<Cleaning>();

    public virtual ICollection<Renovation> Renovations { get; set; } = new List<Renovation>();

    public virtual ICollection<Rentalroom> Rentalrooms { get; set; } = new List<Rentalroom>();

    public virtual Roomtype? Roomtype { get; set; }
}
