using System;
using ConsoleTheater.Models;

namespace ConsoleTheater
{
  class Program
  {
    static void Main(string[] args)
    {
      Theater myTheater = new Theater("Mark's Megaplex");
      myTheater.Initialize();
      Movie titanic = new Movie("Titanic");
      // myTheater.Movies.Add(titanic);
      myTheater.AddRoom(titanic, 100);
      myTheater.AddShowtime("12:00", 0);
      myTheater.AddShowtime("3:00", 0);
      myTheater.AddShowtime("5:20", 0);
      myTheater.AddShowtime("8:30", 0);
      Movie lotr = new Movie("Lord of the Rings");
      myTheater.AddRoom(lotr, 80);
      myTheater.AddShowtime("12:00", 1);
      myTheater.AddShowtime("3:00", 1);
      myTheater.AddShowtime("5:20", 1);
      myTheater.AddShowtime("8:30", 1);
      System.Console.WriteLine($"WELCOME TO {myTheater.Name} Please select a movie:");
      myTheater.PrintMovies();

    }
  }
}
