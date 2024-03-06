using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPCTech2024SpringOrderSystem.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }    
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public ICollection<Order> Orders { get; set; }

    public override string ToString()
    {
        return $"""
            Name: {FirstName} {LastName}
            Address: {Address}
            Phone: {Phone}
            Email: {Email}

            """;
    }
}
