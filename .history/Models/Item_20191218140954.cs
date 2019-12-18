using System;
using System.ComponentModel.DataAnnotations;

namespace company_inventory.Models
{
  public class Item
  {
    public int Id { get; set; }
    public string ProductName { get; set; }

    public int SKU { get; set; }
    public string Description { get; set; }

    public int NumberInStock { get; set; }

    public int Price { get; set; }

    public DateTime DateOrdered { get; set; } = DateTime.Now;
  }
}