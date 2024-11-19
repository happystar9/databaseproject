using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Roomtype
{
    public int Id { get; set; }

    public string Typename { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
