using System.Linq;
using Microsoft.AspNetCore.Mvc;
using company_inventory.Models;

namespace company_inventory.Models
{
  [ApiController]
  [Route("api/[controller]")]

  public class ItemController : ControllerBase
  {
    [HttpGet]

    public ActionResult GetAllItems()
    {
      var db = new DatabaseContext();
      return Ok(db.Items.OrderBy(item => item.ProductName));
    }
    [HttpGet("id")]
    public ActionResult GetOneItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(item => item.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }
    [HttpPost]
    public ActionResult CreateItem(Item item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return Ok(item);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateItem(int id, Item item)
    {
      var db = new DatabaseContext();
      var prevItem = db.Items.FirstOrDefault(item => item.Id == item.Id);
      if (prevItem == null)
      {
        return NotFound();
      }
      else
      {
        prevItem.ProductName = item.ProductName;
        prevItem.SKU = item.SKU;
        prevItem.Description = item.Description;
        prevItem.NumberInStock = item.NumberInStock;
        prevItem.Price = item.Price;
        prevItem.DateOrdered = item.DateOrdered;
        db.SaveChanges();
        return Ok(prevItem);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(item => item.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(item);
        db.SaveChanges();
        return Ok();
      }
    }
    [HttpGet("{OutOfStock}")]
    public ActionResult OutOfStock(int NumberInStock)
    {
      var db = new DatabaseContext();
      var outOfStockItem = db.Items.OrderByDescending(item => item.NumberInStock == 0);
      return Ok(outOfStockItem);
    }

  }
}