namespace Company_v_2._0;

public interface IEmployeeManager<T> where T : Employee
{
    T Gett(string name);
    void Add(T employee);
    void UpdateP(PartTimeEmployee employee);
    void UpdateF(FullTimeEmployee employee);
    void Delete(T employee);
}