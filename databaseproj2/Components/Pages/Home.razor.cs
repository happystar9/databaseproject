using databaseproj2.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace databaseproj2.Components.Pages
{
    public partial class Home
    {
        static Random rnd = new Random();
        static string randphone { get { return "+1(" + rnd.Next(100, 1000) + ") " + rnd.Next(100, 1000) + "-" + rnd.Next(1000, 10000); } }
        DateOnly runningDate { get; set; }
        public async Task generateData(int iterations = 100)
        {
            for(int x = 0; x<iterations; x++)
            {
                var roomsReady = await context.CleanedAndReadies.ToArrayAsync();

            }
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
