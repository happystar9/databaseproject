using databaseproj2.Data;
using System.Runtime.CompilerServices;

namespace databaseproj2.Components.Pages
{
    public partial class Home
    {
        static Random rnd = new Random();
        
        public async Task add100customers()
        {
            for (int i = 0; i < 100; i++)
            {
                context.Customers.Add(randomCustomer());
            }
            context.SaveChanges();
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
