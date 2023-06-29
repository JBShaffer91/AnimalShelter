using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Data
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
      : base(options)
    {
    }

    public DbSet<Animal>? Animals { get; set; }
  }
}
