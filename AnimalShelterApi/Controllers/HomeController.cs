using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApi.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
