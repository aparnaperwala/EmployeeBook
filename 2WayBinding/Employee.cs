using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WayBinding
{
   public class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public static Employee GetEmployee()
        {
            var employee = new Employee()
            {
                Name = "Susan",
                Title = "CEO"
            };
            return employee;
        }
        /// <summary>
        /// Write Employee to file
        /// </summary>
        /// <param name="employee">the employee object to write</param>
        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name},{employee.Title}";
            //var employeeData= employee.Name + "," + employee.Title;
          FileHelper.WriteTextFileAsync("EmployeeTextFile", employeeData);
        }
    }
}
