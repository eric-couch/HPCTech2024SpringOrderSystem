using HPCTech2024SpringOrderSystem.Data;
using HPCTech2024SpringOrderSystem.Models;

using (StoreContext context = new StoreContext())
{
    Console.Write("Enter First Name:");
    string firstName = Console.ReadLine();
    Console.Write("Enter Last Name:");
    string lastName = Console.ReadLine();

    var customer = (from c in context.Customers
                    where c.FirstName == firstName && c.LastName == lastName
                    select c).FirstOrDefault();

    if (customer is null)
    {
        Customer newCustomer = new Customer
        {
            FirstName = firstName,
            LastName = lastName
        };
        Console.Write("Enter your address: ");
        newCustomer.Address = Console.ReadLine();
    } 

    



}
