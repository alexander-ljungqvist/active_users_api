using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ActiveUserApi.Models;

namespace ActiveUserApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActiveUserController : ControllerBase
  {
    private readonly TodoContext _context;


    public ActiveUserController(TodoContext context)
    {
      _context = context;

      if (_context.TodoItems.Count() == 0)
      {
        _context.TodoItems.Add(new TodoItem { Name = "Item1" });
        _context.SaveChanges();
      }
    }
  }
}