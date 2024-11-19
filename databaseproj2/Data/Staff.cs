using System;
using System.Collections.Generic;

namespace databaseproj2.Data;

public partial class Staff
{
    public int Id { get; set; }

    public string Staffname { get; set; } = null!;

    public string? Phone { get; set; }

    public int? Managerid { get; set; }

    public virtual ICollection<Cleaning> Cleanings { get; set; } = new List<Cleaning>();

    public virtual ICollection<Staff> InverseManager { get; set; } = new List<Staff>();

    public virtual Staff? Manager { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rentalroom> Rentalrooms { get; set; } = new List<Rentalroom>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
