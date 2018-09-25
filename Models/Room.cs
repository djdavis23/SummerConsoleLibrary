using System;
using System.Collections.Generic;

namespace ConsoleTheater.Models
{
  public class Room
  {
    public Movie Movie { get; set; }
    private Dictionary<string, int> Showtimes { get; set; }
    public int MaxSeats { get; set; }

    public void AddShowtime(string time)
    {
      Showtimes.Add(time, MaxSeats);
    }

    public void PrintShowtimes()
    {
      foreach (KeyValuePair<string, int> showtime in Showtimes)
      {
        Console.WriteLine($"{showtime.Key} - Available Seats: {showtime.Value}");
      }
    }

    public List<Ticket> BuyTickets(string showtime, int tickets)
    {
      if (Showtimes.ContainsKey(showtime) && Showtimes[showtime] >= tickets)
      {
        List<Ticket> purchased = new List<Ticket>();
        for (int i = 0; i < tickets; i++)
        {
          purchased.Add(new Ticket(showtime, Movie, 15));
        }
        Showtimes[showtime] -= tickets;
        return purchased;
      }
      return null;
    }
    public Room(Movie movie, int maxSeats)
    {
      Movie = movie;
      MaxSeats = maxSeats;
      Showtimes = new Dictionary<string, int>();
    }
  }
}