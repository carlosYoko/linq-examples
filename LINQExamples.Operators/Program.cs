List<Employee> empolyeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

//// ############################################
//// OrderBy and ThenBy Operators - Method Syntax
//// ############################################
//var results = empolyeeList.Join(departmentList,
//        e => e.DepartmentId,
//        d => d.Id,
//        (emp, dept) => new
//        {
//            Id = emp.Id,
//            FirstName = emp.FirstName,
//            LastName = emp.LastName,
//            AnnualSalary = emp.AnnualSalary,
//            DepartmentId = dept.Id,
//            DepartmentName = dept.LongName,
//        }).OrderBy(o => o.FirstName).ThenBy(o => o.AnnualSalary);

//foreach (var result in results)
//{
//    Console.WriteLine($"First Name: {result.FirstName,-10} Last Name: {result.LastName,-10} Annual Salary: {result.AnnualSalary,10}\tDepartment name: {result.DepartmentName}");
//}

//// ###############################
//// OrderBy Operator - Query Syntax
//// ###############################
var results = from emp in empolyeeList
              join dept in departmentList
              on emp.DepartmentId equals dept.Id
              orderby emp.DepartmentId, emp.AnnualSalary descending
              select new
              {
                  Id = emp.Id,
                  FirstName = emp.FirstName,
                  LastName = emp.LastName,
                  AnnualSalary = emp.AnnualSalary,
                  DepartmentId = dept.Id,
                  DepartmentName = dept.LongName,
              };

foreach (var result in results)
{
    Console.WriteLine($"First Name: {result.FirstName,-10} Last Name: {result.LastName,-10} Annual Salary: {result.AnnualSalary,10}\tDepartment name: {result.DepartmentName}");
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