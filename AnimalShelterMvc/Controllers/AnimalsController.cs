using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterMvc.Models;
using System.Text.Json;

namespace AnimalShelterMvc.Controllers
{
  public class AnimalsController : Controller
  {
    private static readonly HttpClient client = new HttpClient();

    // GET: Animals
    public async Task<IActionResult> Index()
    {
      var response = await client.GetAsync("https://localhost:5001/api/Animals");

      if (response.IsSuccessStatusCode)
      {
        var responseBody = await response.Content.ReadAsStringAsync();
        var animals = JsonSerializer.Deserialize<List<Animal>>(responseBody);

        return View(animals);
      }

      return NotFound();
    }
  }
}
