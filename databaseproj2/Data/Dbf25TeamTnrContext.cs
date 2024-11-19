using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace databaseproj2.Data;

public partial class Dbf25TeamTnrContext : DbContext
{
    public Dbf25TeamTnrContext()
    {
    }

    public Dbf25TeamTnrContext(DbContextOptions<Dbf25TeamTnrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addionalfee> Addionalfees { get; set; }

    public virtual DbSet<CleanedAndReady> CleanedAndReadies { get; set; }

    public virtual DbSet<Cleaning> Cleanings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Renovation> Renovations { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Rentalroom> Rentalrooms { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomtype> Roomtypes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Addionalfee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addionalfees_pkey");

            entity.ToTable("addionalfees", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Itemcost)
                .HasColumnType("money")
                .HasColumnName("itemcost");
            entity.Property(e => e.Itemname)
                .HasMaxLength(50)
                .HasColumnName("itemname");
            entity.Property(e => e.Rentalid).HasColumnName("rentalid");

            entity.HasOne(d => d.Rental).WithMany(p => p.Addionalfees)
                .HasForeignKey(d => d.Rentalid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("addionalfees_rentalid_fkey");
        });

        modelBuilder.Entity<CleanedAndReady>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("cleaned_and_ready", "motel007");

            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Typename)
                .HasMaxLength(40)
                .HasColumnName("typename");
        });

        modelBuilder.Entity<Cleaning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cleaning_pkey");

            entity.ToTable("cleaning", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Datecleaned).HasColumnName("datecleaned");
            entity.Property(e => e.Foroccupancy)
                .HasDefaultValue(false)
                .HasColumnName("foroccupancy");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Staffid).HasColumnName("staffid");

            entity.HasOne(d => d.Room).WithMany(p => p.Cleanings)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cleaning_roomid_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.Cleanings)
                .HasForeignKey(d => d.Staffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cleaning_staffid_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Customername)
                .HasMaxLength(50)
                .HasColumnName("customername");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.ToTable("payment", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Amountpaid)
                .HasColumnType("money")
                .HasColumnName("amountpaid");
            entity.Property(e => e.Paymentdate).HasColumnName("paymentdate");
            entity.Property(e => e.Rentalid).HasColumnName("rentalid");
            entity.Property(e => e.Staffid).HasColumnName("staffid");

            entity.HasOne(d => d.Rental).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Rentalid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_rentalid_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Staffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_staffid_fkey");
        });

        modelBuilder.Entity<Renovation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("renovation_pkey");

            entity.ToTable("renovation", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Room).HasColumnName("room");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.RoomNavigation).WithMany(p => p.Renovations)
                .HasForeignKey(d => d.Room)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("renovation_room_fkey");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rental_pkey");

            entity.ToTable("rental", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Checkin).HasColumnName("checkin");
            entity.Property(e => e.Reservation).HasColumnName("reservation");
            entity.Property(e => e.Roomtypeid).HasColumnName("roomtypeid");

            entity.HasOne(d => d.ReservationNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.Reservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_reservation_fkey");

            entity.HasOne(d => d.Roomtype).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.Roomtypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_roomtypeid_fkey");
        });

        modelBuilder.Entity<Rentalroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rentalroom_pkey");

            entity.ToTable("rentalroom", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Checkoutdate).HasColumnName("checkoutdate");
            entity.Property(e => e.Nightlyprice)
                .HasColumnType("money")
                .HasColumnName("nightlyprice");
            entity.Property(e => e.Rentalid).HasColumnName("rentalid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Staffid).HasColumnName("staffid");

            entity.HasOne(d => d.Rental).WithMany(p => p.Rentalrooms)
                .HasForeignKey(d => d.Rentalid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rentalroom_rentalid_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Rentalrooms)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rentalroom_roomid_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.Rentalrooms)
                .HasForeignKey(d => d.Staffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rentalroom_staffid_fkey");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_pkey");

            entity.ToTable("report", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Occupancy)
                .HasDefaultValueSql("0.00")
                .HasColumnName("occupancy");
            entity.Property(e => e.Reportddate).HasColumnName("reportddate");
            entity.Property(e => e.Revenue)
                .HasDefaultValueSql("0.00")
                .HasColumnType("money")
                .HasColumnName("revenue");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservation_pkey");

            entity.ToTable("reservation", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Costomerid).HasColumnName("costomerid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Roomtypeid).HasColumnName("roomtypeid");
            entity.Property(e => e.Staffid).HasColumnName("staffid");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.Costomer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Costomerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservation_costomerid_fkey");

            entity.HasOne(d => d.Roomtype).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Roomtypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservation_roomtypeid_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Staffid)
                .HasConstraintName("reservation_staffid_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_pkey");

            entity.ToTable("room", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Roomnumber)
                .HasMaxLength(6)
                .HasColumnName("roomnumber");
            entity.Property(e => e.Roomtypeid).HasColumnName("roomtypeid");

            entity.HasOne(d => d.Roomtype).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Roomtypeid)
                .HasConstraintName("room_roomtypeid_fkey");
        });

        modelBuilder.Entity<Roomtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roomtype_pkey");

            entity.ToTable("roomtype", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Typename)
                .HasMaxLength(40)
                .HasColumnName("typename");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_pkey");

            entity.ToTable("staff", "motel007");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Managerid).HasColumnName("managerid");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Staffname)
                .HasMaxLength(50)
                .HasColumnName("staffname");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.Managerid)
                .HasConstraintName("staff_managerid_fkey");
        });
        modelBuilder.HasSequence("addionalfees_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("cleaning_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("customer_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("payment_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("renovation_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("rental_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("rentalroom_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("reservation_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("room_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("roomtype_id_seq", "motel007").HasMax(2147483647L);
        modelBuilder.HasSequence("staff_id_seq", "motel007").HasMax(2147483647L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
