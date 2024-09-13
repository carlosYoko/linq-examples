using System.Collections;
using System.Diagnostics.CodeAnalysis;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

//// ############################################
//// OrderBy and ThenBy Operators - Method Syntax
//// ############################################
//var results = employeeList.Join(departmentList,
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
//var results = from emp in employeeList
//              join dept in departmentList
//              on emp.DepartmentId equals dept.Id
//              orderby emp.DepartmentId, emp.AnnualSalary descending
//              select new
//              {
//                  Id = emp.Id,
//                  FirstName = emp.FirstName,
//                  LastName = emp.LastName,
//                  AnnualSalary = emp.AnnualSalary,
//                  DepartmentId = dept.Id,
//                  DepartmentName = dept.LongName,
//              };

//foreach (var result in results)
//{
//    Console.WriteLine($"First Name: {result.FirstName,-10} Last Name: {result.LastName,-10} Annual Salary: {result.AnnualSalary,10}\tDepartment name: {result.DepartmentName}");
//}


//// #################################
//// ToLookup Operator - Method Syntax
//// #################################
//var groupResult = employeeList.OrderBy(o => o.DepartmentId).ToLookup(e => e.DepartmentId);

//foreach (var empGroup in groupResult)
//{
//    Console.WriteLine($"Department Id: {empGroup.Key}");
//    foreach (Employee emp in empGroup)
//    {
//        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
//    }
//}


//// ###############################
//// GroupBy Operator - Query Syntax
//// ###############################
//var groupResult = from emp in employeeList
//                  orderby emp.Id
//                  group emp by emp.DepartmentId;

//foreach (var empGroup in groupResult)
//{
//    Console.WriteLine($"Department Id: {empGroup.Key}");
//    foreach (Employee emp in empGroup)
//    {
//        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
//    }
//}


//// #######################################
//// All, Any, Contains Quantifier Operators
//// #######################################
//var annualSalaryCompare = 20000;
//bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);

//if (isTrueAll)
//{
//    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
//}
//else
//{
//    Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
//}

//bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
//if (isTrueAll)
//{
//    Console.WriteLine($"At least one employee has an annual salary above {annualSalaryCompare}");
//}
//else
//{
//    Console.WriteLine($"No employees have an annual salary above {annualSalaryCompare}");
//}


//// #################
//// Contains Operator
//// #################
//var searchEmployee = new Employee()
//{
//    Id = 3,
//    FirstName = "Bob",
//    LastName = "Marley",
//    AnnualSalary = 40000,
//    IsManager = false,
//    DepartmentId = 2,
//};
//bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());

//if (containsEmployee)
//{
//    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
//}
//else
//{
//    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was not found");
//}

//// #######################
//// OffType filter Operator
//// #######################
//ArrayList mixedCollection = Data.GetHeterogenousDataCollection();
//var stringResult = from s in mixedCollection.OfType<string>()
//                   select s;

//var intResult = from s in mixedCollection.OfType<int>()
//                select s;

//foreach (var i in intResult)
//{
//    Console.WriteLine(i 
//}

// #######################################
// ElementAt, ElementAtOrDefault Operators
// #######################################
//var emp = employeeList.ElementAt(2);
//Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");

//var emp = employeeList.ElementAtOrDefault(999);
//if (emp != null) Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
//else Console.WriteLine("This employee record does nort exist within the collection"); ;


//// #####################################################
//// First, FirstOrDedfault, Last, LastOrDefault Operators
//// #####################################################
//List<int> integerList = new List<int>() { 1, 5, 6, 7, 9, 8 };

//int firstResult = integerList.First();
//int firstOddResult = integerList.First(i => i % 2 == 0);

//int lastResult = integerList.Last();
//int lastOddResult = integerList.Last(i => i % 2 == 0);

Console.ReadKey();


//// #################################
//// Single, SingLeOrDefault Operators
//// #################################
var employeeSingle = employeeList.Single();
var employeeSingleOrDefault = employeeList.SingleOrDefault(e => e.Id == 2);

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

    public static ArrayList GetHeterogenousDataCollection()
    {
        ArrayList arrayList = new ArrayList();

        arrayList.Add(100);
        arrayList.Add("Richard Stallman");
        arrayList.Add(2000);
        arrayList.Add(3000);
        arrayList.Add("Linus Torvalds");
        arrayList.Add(new Employee() { Id = 6, FirstName = "Bob", LastName = "Dylan", AnnualSalary = 70000, IsManager = false, DepartmentId = 4 });
        arrayList.Add(new Employee() { Id = 7, FirstName = "Keit", LastName = "Richards", AnnualSalary = 80000, IsManager = false, DepartmentId = 5 });
        arrayList.Add(new Department() { Id = 4, ShortName = "R&D", LongName = "Research and Development" });
        arrayList.Add(new Department() { Id = 5, ShortName = "MKT", LongName = "Marketing" });

        return arrayList;
    }
}