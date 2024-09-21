﻿
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
//List<int> integerList1 = new List<int> { 1, 2, 3, 4 };
//List<int> integerList2 = new List<int> { 5, 6, 7, 8 };
//IEnumerable<int> integerListConcat = integerList1.Concat(integerList2);

//List<Employee> employeeList2 = new List<Employee> { new Employee() { Id = 5, FirstName = "Ayrton", LastName = "Senna" } };
//IEnumerable<Employee> results = employeeList.Concat(employeeList2);


//// ###################
//// Aggregate Operators
//// ###################
//// Aggregate
//decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0, (totalAnnualSalary, e) =>
//{
//    var bonus = (e.IsManager) ? 0.04m : 0.02m;
//    totalAnnualSalary = (e.AnnualSalary + (e.AnnualSalary * bonus)) + totalAnnualSalary;

//    return totalAnnualSalary;
//});

//Console.WriteLine($"Total annual salary of all employees: {totalAnnualSalary}");

//string data = employeeList.Aggregate<Employee, string>("Employee Annual Salaries (including bouns):\n",
//    (s, e) =>
//    {
//        var bonus = (e.IsManager) ? 0.04m : 0.02m;
//        s += $"{e.FirstName} {e.LastName} - {e.AnnualSalary + (e.AnnualSalary * bonus)}\n";
//        return s;
//    }
//    );

//Console.WriteLine(data);

//// Average
//decimal average = employeeList.Average(e => e.AnnualSalary);
//Console.WriteLine($"Average annual salary: {average}");

//// Count
//int countEmployees = employeeList.Count();
//Console.WriteLine($"Number of Employees: {countEmployees}");

//int countEmployeesInDepartment = employeeList.Count(e => e.DepartmentId == 2);
//var department = departmentList.Where(e => e.Id == 2).FirstOrDefault();
//Console.WriteLine($"Number of Employees in {department.LongName} department: {countEmployeesInDepartment}");

//// Sum
//decimal result = employeeList.Sum(e => e.AnnualSalary);
//Console.WriteLine($"Total Annual Salaires: {result}");

//// Max
//decimal result = employeeList.Max(e => e.AnnualSalary);
//Console.WriteLine($"Max Annual Salary: {result}");

//// ####################
//// Generation Operators
//// ####################
//// DefaultIfEmpty
//List<int> intList = new List<int>();
//var newList = intList.DefaultIfEmpty();
//Console.WriteLine(newList.ElementAt(0));

//List<Employee> employees = new List<Employee>();
//var newList2 = employees.DefaultIfEmpty(new Employee { Id = 0 });
//var result = newList2.ElementAt(0);
//if (result.Id == 0) Console.WriteLine("The list is empty");

//// Empty
//List<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();
//emptyEmployeeList.Add(new Employee { Id = 7, FirstName = "Matt", LastName = "Pocock" });
//foreach (Employee employee in emptyEmployeeList)
//{
//    Console.WriteLine($"{employee.FirstName} {employee.LastName}");
//}

//// Range
//var intCollection = Enumerable.Range(25, 20);
//foreach (int item in intCollection)
//{
//    Console.WriteLine(item);
//}

//// Repeat
//var strCollection = Enumerable.Repeat<string>("Placeholder", 10);
//foreach (var item in strCollection)
//{
//    Console.WriteLine(item);
//}

//// #############
//// Set Operators
//// #############
//// Distinct
//List<int> list = new List<int> { 2, 1, 3, 4, 5, 6, 7, 8, 4, 24, 5, 63, 2, 12, 3, 1 };
//var results = list.Distinct();
//foreach (var result in results)
//{
//    Console.WriteLine(result);
//}

//// Except
IEnumerable<int> collection1 = new List<int>() { 1, 2, 3, 4 };
IEnumerable<int> collection2 = new List<int>() { 3, 4, 5, 6 };
var results = collection1.Except(collection2);
foreach (var result in results)
{
    Console.WriteLine(result);
}

List<int> nums = new List<int> { 3, 1, 2, 45 };
nums.Sort();

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