namespace ConsoleTheater.Interfaces
{
  public interface IPurchasable
  {
    decimal Price { get; set; }
    string Type { get; set; }

    void PrintName();
  }
}