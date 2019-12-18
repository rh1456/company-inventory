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


  }
}