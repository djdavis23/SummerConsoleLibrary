using System;
using System.Collections.Generic;
using ConsoleTheater.Interfaces;

namespace ConsoleTheater.Models
{
  public class Theater
  {
    public string Name { get; private set; }
    public List<IPurchasable> cart { get; set; }
    public List<Concession> Concessions { get; set; }
    private List<Room> Rooms { get; set; }


    public void Initialize()
    {
      Concessions.Add(new Concession("popcorn", 12.54m));
      Concessions.Add(new Concession("candy", 5.00m));
      Concessions.Add(new Concession("drink", 8.00m));
    }

    public void PrintConcessions()
    {
      for (int i = 0; i < Concessions.Count; i++)
      {
        System.Console.WriteLine($"{i + 1} - {Concessions[i].Name}, ${Concessions[i].Price}");
      }
    }

    public void BuyConcession(int index, int quantity)
    {
      for (int i = 0; i < quantity; i++)
      {
        cart.Add(Concessions[index]);
      }
    }

    public decimal PrintCart()
    {
      decimal total = 0.00m;
      cart.ForEach(item =>
      {
        total += item.Price;
        System.Console.WriteLine($"{item.Type}  ${item.Price}");
      });
      System.Console.WriteLine($"\nTOTAL:  {total}");
      return total;
    }

    public bool CartEmpty()
    {
      return cart.Count == 0;
    }

    public void EmptyCart()
    {
      cart.RemoveRange(0, cart.Count);
    }

    public void AddRoom(Movie movie, int seats)
    {
      Rooms.Add(new Room(movie, seats));
    }

    public int GetNumRooms()
    {
      return Rooms.Count;
    }

    public void AddShowtime(string showtime, int roomIndex)
    {
      Rooms[roomIndex].AddShowtime(showtime);
    }

    public bool ValidShowTime(int index, string time)
    {
      return Rooms[index].ValidShowTime(time);
    }

    public void PrintMovies()
    {
      for (int i = 0; i < Rooms.Count; i++)
      {
        Console.WriteLine($@"
{i + 1}. {Rooms[i].Movie.Title}
Showtimes:");
        Rooms[i].PrintShowtimes();
      }
    }

    public bool BuyTickets(int roomindex, string showtime, int number)
    {
      List<Ticket> tickets = Rooms[roomindex].BuyTickets(showtime, number);
      if (tickets == null) { return false; }
      tickets.ForEach(ticket => cart.Add(ticket));
      return true;
    }

    public Theater(string name)
    {
      Name = name;
      //Movies = new List<Movie>();
      Rooms = new List<Room>();
      Concessions = new List<Concession>();
      cart = new List<IPurchasable>();
    }
  }
}