using HPCTech2024SpringOrderSystem.Data;
using HPCTech2024SpringOrderSystem.Models;

using (StoreContext context = new StoreContext())
{
    Product meatLovers = new()
    {
        Name = "Meat Lovers", 
        Price = 9.99m 
    };

    context.Products.Add(meatLovers);
    // EDM - this adds it to the entity, but not the database

    Product deluxePizza = new()
    {
        Name = "Deluxe Pizza",
        Price = 12.99m
    };

    context.Products.Add(deluxePizza);

    context.SaveChanges();
    // this is where it adds the products to the database

}
