namespace Fundamentals.Classes;

public static class ClassTest
{
    public static void Execute()
    {
        Car ferrari = new Car // Inicialização de objeto com inicializador de objeto
        {
            Model = "Ferrari SF90 Stradale",
            ReleaseDate = new DateOnly(2020, 1, 1),
            Color = Color.Red
        };

        Car porsche = new Car( // Inicialização de objeto pelo construtor
            "Porsche 911 Carrera",
            new DateOnly(2025, 1, 1),
            Color.Blue
        );

        Car ford = new Car( // Inicialização de objeto usando construtor e inicializador de objeto
            "Ford Mustang GT"
        )
        {
            ReleaseDate = new DateOnly(2024, 1, 1),
            Color = Color.Black
        };

        ferrari.PrintAttributes();
        porsche.PrintAttributes();
        ford.PrintAttributes();
    }
}
