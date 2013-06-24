using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    public class SalariesMain
    {
        private const char IsSubordinate = 'Y';

        static void Main()
        {
            var allEmployees = ReadInput();
            var allSalaries = 0L;

            foreach (var employee in allEmployees)
            {
                CalculateSalary(employee.Value);
                allSalaries += employee.Value.Salary;
            }

            Console.WriteLine(allSalaries);
        }

        private static void CalculateSalary(Employee employee)
        {
            if (employee.Salary != 0)
            {
                return;
            }

            if (employee.Subordinates.Count == 0)
            {
                employee.Salary = 1;
                return;
            }

            foreach (var subordinate in employee.Subordinates)
            {
                if (subordinate.Salary == 0)
                {
                    CalculateSalary(subordinate);
                }

                employee.Salary += subordinate.Salary;
            }   
        }

        private static Dictionary<int, Employee> ReadInput()
        {
            var allEmployeesCount = int.Parse(Console.ReadLine());
            var allEmployees = new Dictionary<int, Employee>();

            for (int i = 0; i < allEmployeesCount; i++)
            {
                AddEmployeeIfMissing(i, allEmployees);
                var currentEmployee = allEmployees[i];

                var employeeSubordianates = Console.ReadLine();
                for (int j = 0; j < employeeSubordianates.Length; j++)
                {
                    if (employeeSubordianates[j] == IsSubordinate)
                    {
                        AddEmployeeIfMissing(j, allEmployees);
                        currentEmployee.Subordinates.Add(allEmployees[j]);
                    }
                }
            }

            return allEmployees;
        }
  
        private static void AddEmployeeIfMissing(int name, Dictionary<int, Employee> allEmployees)
        {
            if (!allEmployees.ContainsKey(name))
            {
                allEmployees.Add(name, new Employee(name));
            }
        }
    }

    public class Employee
    {
        public int Name { get; set; }
        public long Salary { get; set; }
        public List<Employee> Subordinates { get; set; }

        public Employee(int name)
        {
            this.Name = name;
            this.Salary = 0;
            this.Subordinates = new List<Employee>();
        }
    }
}
