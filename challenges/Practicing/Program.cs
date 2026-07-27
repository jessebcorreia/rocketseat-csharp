using Practicing;
using Practicing.Exercises;

string menuTitle = "Practicing";
List<MenuItem> menuItems = new();

menuItems.Add(new MenuItem(0, "ExecuteAll", Exercises.ExecuteAll));
menuItems.Add(new MenuItem(1, "Welcome", Welcome.Execute));
menuItems.Add(new MenuItem(2, "Calculator", Calculator.Execute));
menuItems.Add(new MenuItem(3, "VehiclePlateValidator", VehiclePlateValidator.Execute));
menuItems.Add(new MenuItem(4, "DateFormatter", DateFormatter.Execute));

Menu menu = new(menuTitle, menuItems);
menu.Execute();
