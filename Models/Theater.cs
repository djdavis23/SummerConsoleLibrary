using System.Collections.Generic;

namespace ConsoleTheater.Models
{
  public class Theater
  {
    public string Name { get; private set; }
    public List<Movie> Movies { get; set; }
    public List<Concession> Concessions { get; set; }
    public List<Room> Rooms { get; set; }

    public Theater(string name)
    {
      Name = name;
      Movies = new List<Movie>();
      // Concessions = new List<Concession>();
    }
  }
}