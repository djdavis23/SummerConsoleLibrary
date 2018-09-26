using System;
using ConsoleTheater.Models;

namespace ConsoleTheater
{
  class Program
  {
    static void Main(string[] args)
    {
      //INITIALIZE THEATER AND ADD MOVIES
      Theater myTheater = new Theater("The Majestic!");
      myTheater.Initialize();
      Movie titanic = new Movie("Titanic");
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
      Movie thor = new Movie("Thor");
      myTheater.AddRoom(thor, 120);
      myTheater.AddShowtime("12:00", 2);
      myTheater.AddShowtime("3:00", 2);
      myTheater.AddShowtime("5:20", 2);
      myTheater.AddShowtime("8:30", 2);
      Movie incredibles = new Movie("Incredibles 2");
      myTheater.AddRoom(incredibles, 100);
      myTheater.AddShowtime("12:00", 3);
      myTheater.AddShowtime("3:00", 3);
      myTheater.AddShowtime("5:30", 3);
      myTheater.AddShowtime("8:30", 3);

      //CLEAR CONSOLE AND DISPLAY SHOWINGS
      System.Console.Clear();
      System.Console.WriteLine($"WELCOME TO {myTheater.Name} We are currently showing the following movies.");
      myTheater.PrintMovies();
      bool purchasing = true;

      //STAY IN MAIN MENU LOOP UNTIL USER CHOOSES TO EXIT
      while (purchasing)
      {
        System.Console.WriteLine("\nWhat would you like to do?\n");
        Console.WriteLine("1 - ORDER MOVIE TICKETS");
        Console.WriteLine("2 - ORDER CONCESSIONS");
        System.Console.WriteLine("3 - CHECKOUT");
        Console.WriteLine("4 - EXIT APP");

        string choice = Console.ReadLine();

        //REACT TO SELECTION FROM MAIN MENU
        switch (choice)
        {
          case "1": //ORDER MOVIE TICKETS
            bool orderTickets = true;
            Console.Clear();
            myTheater.PrintMovies();
            while (orderTickets)
            {
              Console.Write("\nEnter desired movie number or 'X' to return to main menu: ");
              string movieChoice = Console.ReadLine();
              if (movieChoice.ToUpper() == "X")
              {
                orderTickets = false;
                break;
              }
              bool parsed = Int32.TryParse(movieChoice, out int roomIndex);
              bool validChoice = parsed && roomIndex > 0 && roomIndex <= myTheater.GetNumRooms();
              if (!validChoice)
              {
                System.Console.WriteLine("\nInvalid selection.  Please choose again");
                continue;
              }
              roomIndex = roomIndex - 1;
              Console.Write("\nEnter desired showtime(hh:mm): ");
              string showtime = Console.ReadLine();
              if (!myTheater.ValidShowTime(roomIndex, showtime))
              {
                Console.WriteLine("\nInvalid show time.  Please choose again");
                continue;
              }
              Console.Write("\nHow many tickets do you wish to purchase?  ");
              if (!Int32.TryParse(Console.ReadLine(), out int numTickets))
              {
                Console.WriteLine("\nCould not read input.  Please try again");
                continue;
              }
              if (!myTheater.BuyTickets(roomIndex, showtime, numTickets))
              {
                Console.WriteLine("Insufficient seats remaining.  Would you like to select another movie or showtime (Y/N)?");
                if (Console.ReadLine().ToUpper() == "Y") { continue; }
                else
                {
                  orderTickets = false;
                  break;
                }
              }
              Console.WriteLine($"\n{numTickets} tickets added to your cart.  Would you like to purchase more movie tickets?");
              if (Console.ReadLine().ToUpper() == "Y")
              {
                Console.Clear();
                myTheater.PrintMovies();
                continue;
              }
              else { orderTickets = false; }
            }
            break;

          case "2": //ORDER CONCESSIONS
            bool orderConcessions = true;
            Console.Clear();
            myTheater.PrintConcessions();
            while (orderConcessions)
            {
              Console.Write("\nEnter desired item number or 'X' to return to main menu: ");
              string snackChoice = Console.ReadLine();
              if (snackChoice.ToUpper() == "X")
              {
                orderConcessions = false;
                break;
              }
              bool parsed = Int32.TryParse(snackChoice, out int foodIndex);
              bool validChoice = parsed && foodIndex > 0 && foodIndex <= myTheater.Concessions.Count;
              if (!validChoice)
              {
                System.Console.WriteLine("\nInvalid selection.  Please choose again");
                continue;
              }
              foodIndex = foodIndex - 1;
              Console.Write($"\nHow many {myTheater.Concessions[foodIndex].Name} do you wish to purchase?  ");
              if (!Int32.TryParse(Console.ReadLine(), out int numFood))
              {
                Console.WriteLine("\nCould not read input.  Please try again");
                continue;
              }
              myTheater.BuyConcession(foodIndex, numFood);
              Console.WriteLine($"\n{numFood} {myTheater.Concessions[foodIndex].Name} added to your cart.  Would you like to purchase more movie snacks?");
              if (Console.ReadLine().ToUpper() == "Y")
              {
                Console.Clear();
                myTheater.PrintConcessions();
                continue;
              }
              else { orderConcessions = false; }
            }
            break;

          case "3": //CHECKOUT
            if (myTheater.CartEmpty())
            {
              System.Console.WriteLine("\nYour Cart is Empty");
              continue;
            }
            Console.WriteLine("\n\nCart Contents:\n");
            decimal total = myTheater.PrintCart();
            Console.Write("\nDo you wish to continue checking out (Y/N)?  ");
            if (Console.ReadLine().ToUpper() != "Y")
            {
              continue;
            }
            myTheater.EmptyCart();
            Console.WriteLine($"\nA total of ${total} has been charged to your account.");
            break;

          case "4": //EXIT APP
            if (!myTheater.CartEmpty())
            {
              Console.WriteLine("You have items in your cart.  Do you wish to continue exiting (Y/N)");
              if (Console.ReadLine().ToUpper() != "Y")
              {
                continue;
              }
              myTheater.EmptyCart();
            }
            purchasing = false;
            break;
          default:
            System.Console.WriteLine("\n\nInvalid selection.  Please select again");
            break;
        }

      }
      System.Console.WriteLine("\nHAVE A GREAT DAY!");
    }
  }
}
