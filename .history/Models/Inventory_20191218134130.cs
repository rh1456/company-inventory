using System.ComponentModel.DataAnnotations;

namespace company_inventory.Models
{
  public class Inventory
  {
    public int Id { get; set; }
    public string ProductName { get; set; }
  }
}