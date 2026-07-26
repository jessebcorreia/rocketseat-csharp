namespace FirstAPI.Entities;

public class User
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }

    public User(int id, int age, string name)
    {
        Id = id;
        Age = age;
        Name = name;
    }

    public User() { }
}
