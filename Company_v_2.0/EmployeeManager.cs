using System.Reflection;

namespace Company_v_2._0;

public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
    public List<T> employees = new List<T>();

    public void Add(T employee)
    {
        employees.Add(employee);
    }

    public void UpdateF(FullTimeEmployee employee)
    {
        try
        {
            Console.Write("Input new name: ");
            string newname = Console.ReadLine();
            if (newname == String.Empty)
            {
                Console.WriteLine("Uncorrect name");
                return;
            }

            if (employees.FirstOrDefault(e => e.Name == newname) != null)
            {
                Console.WriteLine("Name already exists");
                return;
            }

            employee.Name = newname;
            Console.Write("Input new Salary: ");
            employee.BaseSalary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Employee updated");
        }
        catch (Exception e)
        {
            Console.WriteLine("Employee not updated. Uncorrect input");
        }
    }

    public void UpdateP(PartTimeEmployee employee)
    {
        try
        {
            Console.Write("Input new name: ");
            string newname = Console.ReadLine();
            if (newname == String.Empty)
            {
                Console.WriteLine("Uncorrect name");
                return;
            }

            if (employees.FirstOrDefault(e => e.Name == newname) != null)
            {
                Console.WriteLine("Name already exists");
                return;
            }

            Console.Write("Input new Rate: ");
            decimal newRate = decimal.Parse(Console.ReadLine());
            Console.Write("Input new Hours: ");
            decimal newHours = decimal.Parse(Console.ReadLine());
            employee.Name = newname;
            employee.Rate = newRate;
            employee.HoursWorked = newHours;
            Console.WriteLine("Employee updated");
        }
        catch (Exception e)
        {
            Console.WriteLine("Employee not updated. Uncorrect input");
        }
    }

    public void Delete(T employee)
    {
        employees.Remove(employee);
    }

    public T Gett(string name)
    {
        // T human = default(T);
        T human = employees.FirstOrDefault(e => e.Name == name);
        return human;
    }

    public string Show(T person)
    {
        string s = "~";
        var fields = person.GetType();
        PropertyInfo[] properties = fields.GetProperties();
        foreach (PropertyInfo p in properties)
        {
            if (p.GetValue(person, null).ToString() == "-1") continue;
            //s += p.Name + " : " + p.GetValue(person, null) + ", ";
            s += $"{p.Name}: {p.GetValue(person, null)}, ";
        }

        s += $"Total Salary: {person.CalculateSalary()}.";
        return s;
    }
}