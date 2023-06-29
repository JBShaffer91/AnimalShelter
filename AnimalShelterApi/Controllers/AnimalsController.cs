using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Data;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _context;

    public AnimalsController(AnimalShelterContext context)
    {
      _context = context;
    }

    // GET: api/Animals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
    {
      return await _context.Animals!.ToListAsync();
    }

    // GET: api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _context.Animals!.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

    // POST: api/Animals
    [HttpPost]
    public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
    {
      _context.Animals!.Add(animal);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnimal(int id, Animal animal)
    {
      if (id != animal.Id)
      {
        return BadRequest();
      }

      _context.Entry(animal).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _context.Animals!.Any(e => e.Id == id);
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _context.Animals!.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _context.Animals!.Remove(animal);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
