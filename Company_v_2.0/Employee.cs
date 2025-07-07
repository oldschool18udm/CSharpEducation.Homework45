namespace Company_v_2._0;

public abstract class Employee
{
    public abstract string Name { get; set; }
    public abstract decimal BaseSalary { get; set; }
    public abstract decimal CalculateSalary();
    
}