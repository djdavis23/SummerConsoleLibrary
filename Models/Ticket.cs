using ConsoleTheater.Interfaces;

namespace ConsoleTheater.Models
{
  public class Ticket : IPurchasable
  {
    public string Time { get; set; }
    public Movie Movie { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }

    public Ticket(string time, Movie movie, decimal price)
    {
      Time = time;
      Movie = movie;
      Price = price;
      Type = "Ticket";
    }

    public void PrintName()
    {
      System.Console.WriteLine($"Ticket for {Movie} at {Time}");
    }
  }
}