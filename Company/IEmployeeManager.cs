namespace Company;

public interface IEmployeeManager<T> where T : Employee
{
    T GetEmployee(string name);
    void Add(T employee);
    void Update(PartTimeEmployee employee,string name, decimal rate, decimal hours);
    void Update(FullTimeEmployee employee, string name, decimal salary);
    void Delete(T employee);
}