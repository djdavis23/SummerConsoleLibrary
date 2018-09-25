using ConsoleTheater.Interfaces;

namespace ConsoleTheater.Models
{
  public class Concession : IPurchasable
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }

    public void PrintName()
    {
      System.Console.WriteLine($"Purchase of {Name} for {Price}");
    }

    public Concession(string name, decimal price)
    {
      Name = name;
      Price = price;
      Type = "Concession";
    }
  }
}