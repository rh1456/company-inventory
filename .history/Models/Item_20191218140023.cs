using System.ComponentModel.DataAnnotations;

namespace company_inventory.Models
{
  public class Item
  {
    public int Id { get; set; }
    public string ProductName { get; set; }

    public int SKU { get; set; }

  }
}