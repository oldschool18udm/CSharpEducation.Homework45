namespace Company_v_2._0;

class Program
{
    public static EmployeeManager<Employee> employeeManager = new EmployeeManager<Employee>();
    static void Main(string[] args)
    {
        bool gameover = false;
        FillList();
        Console.WriteLine("Welcome to the Company");
        while (!gameover)
        {
            Console.WriteLine("Please enter number: ");
            Console.WriteLine("1 - Add  Fulltime employee");
            Console.WriteLine("2 - Add  Parttime employee");
            Console.WriteLine("3 - Update employee");
            Console.WriteLine("4 - Delete employee");
            Console.WriteLine("5 - Show one employee");
            Console.WriteLine("6 - Show employees");

            Console.WriteLine("0 - Exit");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                {
                    addFullTimeUser();
                    break;
                }
                case "2":
                {
                    addPartTimeUser();
                    break;
                }
                case "3":
                {
                    Console.Write("Press name of user to update: ");
                    UpdateUser(Console.ReadLine());
                    break;
                }
                case "4":
                {
                    Console.Write("Press number of user to delete: ");
                    DeleteUser(Console.ReadLine());
                    break;
                }
                case "5":
                {
                    Console.Write("Press name of user to show: ");
                    GetEployee(Console.ReadLine());
                    break;
                }
                case "6":
                {
                    LoadUsers();
                    break;
                }
                case "0":
                {
                    gameover = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("Please enter a valid number");
                    break;
                }
            }
        }

        Console.WriteLine("HASTA LA VISTA");
    }

    public static void FillList()
    {
        for (int i = 0; i < 3; i++)
        {
            FullTimeEmployee employee = new FullTimeEmployee();
            employee.Name = "John" + i.ToString();
            employee.BaseSalary = 100 + i;
            employeeManager.Add(employee);
        }

        for (int i = 0; i < 3; i++)
        {
            PartTimeEmployee employee = new PartTimeEmployee();
            employee.Name = "Jane" + i.ToString();
            employee.Rate = 10 + i;
            employee.HoursWorked = 5 + i;
            employeeManager.Add(employee);
        }
    }

    public static void GetEployee(string name)
    {
        Employee employee = employeeManager.Gett(name);
        if (employee != null)
            Console.WriteLine(employeeManager.Show(employee));
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public static void LoadUsers()
    {
        foreach (Employee employee in employeeManager.employees)
        {
            Console.WriteLine(employeeManager.Show(employee));
        }
    }

    public static void addFullTimeUser()
    {
        try
        {
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (name == String.Empty)
            {
                Console.WriteLine("Uncorrect name");
                return;
            }

            fullTimeEmployee.Name = name;
            Console.Write("Enter full time salary: ");
            fullTimeEmployee.BaseSalary = decimal.Parse(Console.ReadLine());
            Employee e = employeeManager.employees.FirstOrDefault(e => e.Name == fullTimeEmployee.Name);
            if (e == null)
            {
                employeeManager.Add(fullTimeEmployee);
            }
            else
            {
                Console.WriteLine("Employee already exists! Try another one.");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error. Can`t add this Employee. Please try again!");
        }
    }

    public static void addPartTimeUser()
    {
        try
        {
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (name == String.Empty)
            {
                Console.WriteLine("Uncorrect name");
                return;
            }

            partTimeEmployee.Name = name;

            Console.Write("Enter rate: ");
            partTimeEmployee.Rate = decimal.Parse(Console.ReadLine());
            Console.Write("Enter worked hours: ");
            partTimeEmployee.HoursWorked = decimal.Parse(Console.ReadLine());
            Employee e = employeeManager.employees.FirstOrDefault(e => e.Name == partTimeEmployee.Name);
            if (e == null)
            {
                employeeManager.Add(partTimeEmployee);
            }
            else
            {
                Console.WriteLine("Employee already exists! Try another one.");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error. Can`t add this Employee. Please try again!");
        }
    }

    public static void UpdateUser(string name)
    {
        Employee employee = employeeManager.employees.FirstOrDefault(e => e.Name == name);
        if (employee != null)
        {
            if (employee.GetType() == typeof(FullTimeEmployee))
                employeeManager.UpdateF((FullTimeEmployee)employee);
            else
            {
                employeeManager.UpdateP((PartTimeEmployee)employee);
            }
        }
        else
        {
            Console.WriteLine("Employee does not exist!");
        }
    }

    public static void DeleteUser(string name)
    {
        Employee employee = employeeManager.employees.FirstOrDefault(e => e.Name == name);
        if (employee != null)
        {
            employeeManager.Delete(employee);
            Console.WriteLine("Employee deleted!");
        }
        else
        {
            Console.WriteLine("Employee does not exist!");
        }
    }
}