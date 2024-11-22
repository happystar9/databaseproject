using databaseproj2.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace databaseproj2.Components.Pages
{
    public partial class Home
    {
        static Random rnd = new Random();
        static string randphone { get { return "+1(" + rnd.Next(100, 1000) + ") " + rnd.Next(100, 1000) + "-" + rnd.Next(1000, 10000); } }
        public async Task generateData()
        {
        DateOnly runningDate  = DateOnly.Parse("11/19/1975");
            var customers =  await context.Customers.ToArrayAsync();
            var staff = await context.Staff.ToArrayAsync();
            var types = await context.Roomtypes.ToArrayAsync();
            var rooms = await context.Rentalrooms.GroupBy(x => x.Room).Select(x => x.OrderByDescending(a=>a.Checkoutdate).First()).ToArrayAsync();
            logger.LogInformation(rooms.ToString());
            Dictionary<Room, DateOnly?> roomtoend = new Dictionary<Room, DateOnly?>();

            for (int x = 0; x < 500000; x++)
            {
                var start = runningDate.AddDays(x);
                var end = runningDate.AddDays(x+rnd.Next(4));
                var type = types[rnd.Next(types.Length)];
                var reservation = new Reservation() { Costomer = customers[rnd.Next(customers.Length)], Roomtype = type, Enddate = end, Startdate = start, Staff = staff[rnd.Next(staff.Length)] };
                var rental = new Rental() {ReservationNavigation =  reservation, Checkin = start, Roomtype = reservation.Roomtype};
                context.Reservations.Add(reservation);
                context.Rentals.Add(rental);
                var readyRooms =  await context.Rooms.ToArrayAsync();
                var onDateRooms = new List<Room>();
                foreach (Room sa in readyRooms)
                {
                    if (roomtoend.ContainsKey(sa))
                    {
                        if (start > roomtoend[sa]&&sa.Roomtype==type)
                            onDateRooms.Add(sa);
                    }
                else onDateRooms.Add(sa);
                }
                var room = onDateRooms[rnd.Next(onDateRooms.Count-1)];
                roomtoend[room]=end;
                var reroom = new Rentalroom() { Room = room, Checkoutdate = end, Nightlyprice = rnd.Next(100,300), Rental = rental, Staff = staff[rnd.Next(staff.Length)] };
                rental.Rentalrooms.Add(reroom);
                var payment = new Payment() {Staff = staff[rnd.Next(staff.Length)], Amountpaid =  reroom.Nightlyprice*(reroom.Checkoutdate.Value.DayNumber - reroom.Rental.Checkin.DayNumber),
                Rental = rental, Paymentdate = start};
                context.Payments.Add(payment);
                context.Cleanings.Add(new Cleaning() {Foroccupancy = true, Datecleaned = start, Room=room, Staff = staff[rnd.Next(staff.Length)]});
            }
            context.SaveChanges();
        }
        public async Task add100Rooms()
        {
            int roomNumber = 109;  // Starting room number
            for (int i = 0; i < 100; i++)
            {
                if (roomNumber > 209) roomNumber = 109;

                var newRoom = randomRoom(roomNumber);
                context.Rooms.Add(newRoom);

                roomNumber++;
            }
            context.SaveChanges();
        }
        public static Room randomRoom(int roomNumber)
        {
            var roomTypes = new[] { 1, 2, 3 };
            var roomTypeId = roomTypes[rnd.Next(roomTypes.Length)];

            return new Room()
            {
                Roomnumber = roomNumber.ToString(),
                Roomtypeid = roomTypeId
            };
        }
        public async Task add100customers()
        {
            for (int i = 0; i < 100; i++)
            {
                context.Customers.Add(randomCustomer());
            }
            context.SaveChanges();
        }
        public async Task add100staff()
        {
            for (int i = 0; i< 100; i++)
            {
                context.Staff.Add(randomStaff());
            }
            context.SaveChanges();
        }
        public Staff randomStaff()
        {
            var staff = new Staff();
            staff.Manager = context.Staff.Where(f => f.Id == 1).First();
            staff.Staffname = listsStuff.firstNames[rnd.Next(listsStuff.firstNames.Length)] + " "+ listsStuff.lastNames[rnd.Next(listsStuff.lastNames.Length)];
            staff.Phone = randphone;
            return staff;
        }
        
        public static Customer randomCustomer()
        {
            var first = listsStuff.firstNames[rnd.Next(listsStuff.firstNames.Length)];
            var last = listsStuff.lastNames[rnd.Next(listsStuff.lastNames.Length)];
            var email = first + last + "gmail.com";
            var phone = "+1("+ rnd.Next(100, 1000)+") " + rnd.Next(100, 1000)+ "-" + rnd.Next(1000, 10000);
            return new Customer() {Customername=first + " " + last, Email=email,Phonenumber=phone };
        }

    }
}
