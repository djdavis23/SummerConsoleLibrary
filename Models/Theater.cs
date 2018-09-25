using System;
using System.Collections.Generic;
using ConsoleTheater.Interfaces;

namespace ConsoleTheater.Models
{
  public class Theater
  {
    public string Name { get; private set; }
    // public List<Movie> Movies { get; set; }

    public List<IPurchasable> cart { get; set; }
    public List<Concession> Concessions { get; set; }
    private List<Room> Rooms { get; set; }

    public void Initialize()
    {
      Concessions.Add(new Concession("popcorn", 12.54m));
      Concessions.Add(new Concession("snacks", 5.00m));
      Concessions.Add(new Concession("drink", 8.00m));
    }

    public void AddRoom(Movie movie, int seats)
    {
      Rooms.Add(new Room(movie, seats));
    }
    public void AddShowtime(string showtime, int roomIndex)
    {
      Rooms[roomIndex].AddShowtime(showtime);
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
    public Theater(string name)
    {
      Name = name;
      //Movies = new List<Movie>();
      Rooms = new List<Room>();
      Concessions = new List<Concession>();
    }
  }
}