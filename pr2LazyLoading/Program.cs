//В модели Employee навигационные свойства объявлены как virtual
//В конфигурации контекста используется вызов:optionsBuilder.UseLazyLoadingProxies()

using pr2LazyLoading;

class Program
{
	static void Main()
	{
		//создаём экземпляр контекста бд для работы с данными
		using (DbCompanyContext context = new DbCompanyContext())
		{
			// Получение списка сотрудников в список employees
			List<Employee> employees = context.Employees.ToList();

			Console.WriteLine("Загрузка данных с помощью Lazy loading:");

			//проходимся по каждому сотруднику
			foreach (Employee employee in employees)
			{
				// автоматическая загрузка этих связанных записей.
				Console.WriteLine($"Сотрудник: {employee.Name}");
				Console.WriteLine($"Должность: {employee.IdPositionNavigation?.Name}");
				Console.WriteLine($"Отдел: {employee.IdDepartmentNavigation?.Name}");
				Console.WriteLine(); 
			}
		}
	}
}