using HPCTech2024SpringOrderSystem;
using HPCTech2024SpringOrderSystem.Data;
using HPCTech2024SpringOrderSystem.Models;

using (StoreContext context = new StoreContext())
{
    Customer ThisCustomer = new Customer();
    OrderSystem orderSystem = new OrderSystem(context);

    Console.Write("Enter First Name:");
    ThisCustomer.FirstName = Console.ReadLine();
    Console.Write("Enter Last Name:");
    ThisCustomer.LastName = Console.ReadLine();

    var findCustomer = orderSystem.GetCustomer(ThisCustomer);

    if (findCustomer is null)
    {
        //Customer newCustomer = new Customer
        //{
        //    FirstName = firstName,
        //    LastName = lastName
        //};
        //Console.Write("Enter your address: ");
        //newCustomer.Address = Console.ReadLine();
    } 

    



}
