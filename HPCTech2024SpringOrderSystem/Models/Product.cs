using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPCTech2024SpringOrderSystem.Models;

internal class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Price { get; set; }
}
