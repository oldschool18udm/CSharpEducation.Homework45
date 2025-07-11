using Company;

namespace Company;

public class PartTimeEmployee : Employee
{
    public override string Name { get; set; }
    private decimal salary = -1;
    public override decimal BaseSalary
    {
        get { return salary; }
        set { value = salary; }
    }

    public decimal Rate { get; set; }
    public decimal HoursWorked { get; set; }

    public override decimal CalculateSalary()
    {
        return Rate * HoursWorked;
    }
}