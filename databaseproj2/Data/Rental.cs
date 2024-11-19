using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Rental
{
    public int Id { get; set; }

    public int Roomtypeid { get; set; }

    public DateOnly Checkin { get; set; }

    public int Reservation { get; set; }

    public virtual ICollection<Addionalfee> Addionalfees { get; set; } = new List<Addionalfee>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rentalroom> Rentalrooms { get; set; } = new List<Rentalroom>();

    public virtual Reservation ReservationNavigation { get; set; } = null!;

    public virtual Roomtype Roomtype { get; set; } = null!;
}
