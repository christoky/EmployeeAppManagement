using Microsoft.AspNetCore.Mvc;
// Controllers/HomeController.cs
namespace EmploypeeAppManagement.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
      {
        return View();
      }
    public IActionResult About()
      {
        ViewData["Message"] = "UNF School of Computing Faculty and Staff Listing";
        return View();
      }
    public IActionResult Contact()
    {
      ViewData["Message"] = "Office Address:";
      return View();
    }
  }
}
