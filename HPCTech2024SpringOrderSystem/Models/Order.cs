using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPCTech2024SpringOrderSystem.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? OrderFullfilled { get; set; }
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }

    public override string ToString()
    {
        //return $"Order Date: {OrderDate} - Order Fullfilled: {OrderFullfilled?.ToString() ?? ""}";
        return $"""
            Order Date: {OrderDate}
            Order Fullfilled: {OrderFullfilled?.ToString() ?? ""}
            """;
    }
}
