using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Reservation
{
    public int Id { get; set; }

    public int Costomerid { get; set; }

    public int Roomtypeid { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }

    public int? Staffid { get; set; }

    public virtual Customer Costomer { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Roomtype Roomtype { get; set; } = null!;

    public virtual Staff? Staff { get; set; }
}
