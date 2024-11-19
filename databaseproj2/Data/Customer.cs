using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Customer
{
    public int Id { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Customername { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
