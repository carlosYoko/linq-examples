List<Employee> empolyeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

// ##########################################
// Select and WHere Operators - Method Syntax
// ##########################################
//var results = empolyeeList.Select(e => new
//{
//    FullName = e.FirstName + " " + e.LastName,
//    AnnualSalary = e.AnnualSalary,
//}).Where(e => e.AnnualSalary > 50000);

//foreach (var result in results)
//{
//    Console.WriteLine(result.FullName + " " + result.AnnualSalary);
//}

// #########################################
// Select and WHere Operators - Query Syntax
// #########################################
//var results = from emp in empolyeeList
//              where emp.AnnualSalary > 50000
//              select new
//              {
//                  FullName = emp.FirstName + " " + emp.LastName,
//                  AnnualSalary = emp.AnnualSalary
//              };

//foreach (var result in results)
//{
//    Console.WriteLine(result.FullName + " " + result.AnnualSalary);
//}

// ##########################
// Deffered Execution example
// ##########################
//var results = from emp in empolyeeList.GetHighSalariedEmployees()
//              select new
//              {
//                  FullName = emp.FirstName + " " + emp.LastName,
//                  AnnualSalary = emp.AnnualSalary
//              };

//foreach (var result in results)
//{
//    Console.WriteLine(result.FullName + " " + result.AnnualSalary);
//}

// ###########################
// Inmediate Execution example
// ###########################
//var results = (from emp in empolyeeList.GetHighSalariedEmployees()
//               select new
//               {
//                   FullName = emp.FirstName + " " + emp.LastName,
//                   AnnualSalary = emp.AnnualSalary
//               }).ToList();

//foreach (var result in results)
//{
//    Console.WriteLine(result.FullName + " " + result.AnnualSalary);
//}


public static class EnumarableCollectionExtensionMethods
{
    public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
    {
        foreach (Employee emp in employees)
        {
            Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");

            if (emp.AnnualSalary > 50000) yield return emp;
        }
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