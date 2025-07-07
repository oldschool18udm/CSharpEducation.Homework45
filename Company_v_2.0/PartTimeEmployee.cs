namespace Company_v_2._0;

public class PartTimeEmployee:Employee
{
    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }
    public decimal Rate { get; set; }
    public decimal HoursWorked { get; set; }

    public override decimal CalculateSalary()
    {
        return Rate * HoursWorked;
    }

    public PartTimeEmployee()
    {
        this.BaseSalary = -1;
    }
}