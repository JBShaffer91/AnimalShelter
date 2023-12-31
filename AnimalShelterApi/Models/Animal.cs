namespace AnimalShelterApi.Models
{
  public class Animal
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public string? Breed { get; set; }
    public int Age { get; set; }
    public bool IsAdopted { get; set; }
  }
}
