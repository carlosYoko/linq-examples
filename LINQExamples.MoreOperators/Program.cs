
using System.Diagnostics.CodeAnalysis;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

//// ######################
//// SequenceEqual Operator
//// ######################
//var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
//var integerList2 = new List<int> { 1, 2, 3, 4, 5, 6 };
//var boolSequenceEqual = integerList1.SequenceEqual(integerList2);

//var employeeList1 = Data.GetEmployees();
//var employeeList2 = Data.GetEmployees();
//var boolSequenceEmployee = employeeList1.SequenceEqual(employeeList2, new EmployeeComparer());


//// ###############
//// Concat Operator
//// ###############
List<int> integerList1 = new List<int> { 1, 2, 3, 4 };
List<int> integerList2 = new List<int> { 5, 6, 7, 8 };
IEnumerable<int> integerListConcat = integerList1.Concat(integerList2);

List<Employee> employeeList2 = new List<Employee> { new Employee() { Id = 5, FirstName = "Ayrton", LastName = "Senna" } };
IEnumerable<Employee> results = employeeList.Concat(employeeList2);



Console.ReadKey();

public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y)
    {
        if (x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName)
        {
            return true;
        }
        return false;
    }

    public int GetHashCode([DisallowNull] Employee obj)
    {
        return obj.Id.GetHashCode();
    }
}

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}
public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
}

public static class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

        Employee employee = new Employee()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Long",
            AnnualSalary = 60000,
            IsManager = true,
            DepartmentId = 1,
        };
        employees.Add(employee);

        employee = new Employee()
        {
            Id = 2,
            FirstName = "Sara",
            LastName = "Jameson",
            AnnualSalary = 80000,
            IsManager = true,
            DepartmentId = 2,
        };
        employees.Add(employee);

        employee = new Employee()
        {
            Id = 3,
            FirstName = "Bob",
            LastName = "Marley",
            AnnualSalary = 40000,
            IsManager = false,
            DepartmentId = 2,
        };
        employees.Add(employee);

        employee = new Employee()
        {
            Id = 4,
            FirstName = "Faith",
            LastName = "Evans",
            AnnualSalary = 60000,
            IsManager = false,
            DepartmentId = 3,
        };
        employees.Add(employee);

        return employees;
    }

    public static List<Department> GetDepartments()
    {
        List<Department> deparments = new List<Department>();

        Department deparment = new Department()
        {
            Id = 1,
            ShortName = "IT",
            LongName = "Information Tecnology"
        };
        deparments.Add(deparment);

        deparment = new Department()
        {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance"
        };
        deparments.Add(deparment);

        deparment = new Department()
        {
            Id = 3,
            ShortName = "HR",
            LongName = "Human Recourses"
        };
        deparments.Add(deparment);

        return deparments;
    }
}