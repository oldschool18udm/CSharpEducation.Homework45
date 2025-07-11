namespace Company;

public class FullTimeEmployee:Employee
{
    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }

    public override decimal CalculateSalary()
    {
        return BaseSalary;
    }
}