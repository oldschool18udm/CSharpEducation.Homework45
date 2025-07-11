using System.Reflection;

namespace Company;

public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
    public List<T> Employees = new List<T>();

    public void Add(T employee)
    {
        Employees.Add(employee);
    }

    public void Update(PartTimeEmployee employee, string name, decimal rate, decimal hours)
    {
        employee.Name = name;
        employee.Rate = rate;
        employee.HoursWorked = hours;
    }

    public void Update(FullTimeEmployee employee, string name, decimal salary)
    {
        employee.BaseSalary = salary;
        employee.Name = name;
    }

    public void Delete(T employee)
    {
        Employees.Remove(employee);
    }

    public T GetEmployee(string name)
    {
        T human = Employees.FirstOrDefault(e => e.Name == name);
        return human;
    }

    public string Show(T person)
    {
        string s = "~";
        var fields = person.GetType();
        PropertyInfo[] properties = fields.GetProperties();
        foreach (PropertyInfo p in properties)
        {
            if (p.GetValue(person, null).ToString() == "-1")
                continue;
            s += $"{p.Name}: {p.GetValue(person, null)}, ";
        }
        s += $"Total Salary: {person.CalculateSalary()}.";
        return s;
    }
}