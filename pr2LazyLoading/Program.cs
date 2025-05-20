class Program
{
    static void Main()
    {
        using var db = new ApplicationContext();

        var employees = db.Employees.ToList();

        foreach (var e in employees)
        {
            Console.WriteLine($"{e.name} - {e.Position?.title} - {e.Position?.Department?.name}");
        }
    }
}