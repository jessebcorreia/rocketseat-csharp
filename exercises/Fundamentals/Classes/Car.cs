namespace Fundamentals.Classes;

public class Car
{
    public string Model { get; set; } // Autoimplementa os getters e setters na própria declaração do atributo
    public DateOnly ReleaseDate { get; set; }
    public Color Color { get; set; }

    public Car()
    {
    }

    public Car(string model)
    {
        Model = model;
    }

    public Car(string model, DateOnly releaseDate, Color color)
    {
        Model = model;
        ReleaseDate = releaseDate;
        Color = color;
    }

    public void PrintAttributes()
    {
        Console.WriteLine("\nModel: " + this.Model);
        Console.WriteLine("Release Date:" + this.ReleaseDate);
        Console.WriteLine("Color: " + this.Color);
    }
}
