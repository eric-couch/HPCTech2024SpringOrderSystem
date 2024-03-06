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
        Console.WriteLine("Customer not found, create new account.");
        Console.Write("Enter Address: ");
        ThisCustomer.Address = Console.ReadLine();
        Console.Write("Enter Email: ");
        ThisCustomer.Email = Console.ReadLine();
        Console.Write("Enter Phone: ");
        ThisCustomer.Phone = Console.ReadLine();

        orderSystem.AddCustomer(ThisCustomer);
    } else
    {
        ThisCustomer = findCustomer;
        Console.WriteLine("Customer Found.");
        Console.WriteLine(ThisCustomer.ToString());
    }

    bool quitOrder = false;
    do
    {
        Console.WriteLine(OrderSystem.MainMenu());
        string userResponse  = Console.ReadLine()!.ToLower() ?? "";
        if (userResponse == "l")
        {
            Console.Clear();
            List<Order> custOrders = orderSystem.GetOrders(ThisCustomer);
            if (custOrders is null || custOrders.Count == 0)
            {
                Console.WriteLine("No orders found.");
            } else
            {
                Console.WriteLine(orderSystem.OrderOrderDetailOutput(custOrders));
            }
        } else if (userResponse == "p")
        {
            Console.Clear();
            Order newOrder = new Order()
            {
                Customer = ThisCustomer,
                OrderDate = DateTime.Now
            };
            OrderDetail newOrderDetail = new OrderDetail()
            {
                Order = newOrder
            };
            bool doneWithProducts = false;
            do
            {
                Console.WriteLine(orderSystem.OrderMenu());
                string orderItem = Console.ReadLine()!.ToLower() ?? "q";
                if (orderItem == "q")
                {
                    doneWithProducts = true;
                    quitOrder = true;
                }
                else if (Int32.TryParse(orderItem, out int productNumber))
                {
                    var product = orderSystem.GetProduct(productNumber);
                    if (product is null)
                    {
                        Console.WriteLine("Invalid product number.");
                    } else
                    {
                        Console.Write("Enter Quantity: ");
                        string qty = Console.ReadLine()!;
                        if (Int32.TryParse(qty, out int quantity))
                        {
                            newOrderDetail.Quantity = quantity;
                            newOrderDetail.Product = product;
                            orderSystem.AddOrder(newOrder);
                            orderSystem.AddOrderDetail(newOrderDetail);
                        } else
                        {
                            Console.WriteLine("Invalid quantity.");
                        }
                    }
                }
            } while (!doneWithProducts);

        } else if (userResponse == "q")
        {
            quitOrder = true;
        } else
        {
            Console.WriteLine("Invalid Entry.  Try again.");
        }
    } while (!quitOrder);



}
