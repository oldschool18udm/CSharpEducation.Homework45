namespace Company_v_2._0;

public class FullTimeEmployee:Employee
{
    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }

    public override decimal CalculateSalary()
    {
        return BaseSalary;
    }
}