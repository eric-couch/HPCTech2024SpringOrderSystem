using HPCTech2024SpringOrderSystem.Data;
using HPCTech2024SpringOrderSystem.Models;

using (StoreContext context = new StoreContext())
{
    var products = (from p in context.Products
                    where p.Price > 10.00M
                    select p).ToList();

    foreach (var product in products)
    {
        Console.WriteLine($"Product Name:\t{product.Name}");
        Console.WriteLine($"Price:\t{product.Price}");
        Console.WriteLine();
    }

    

}
