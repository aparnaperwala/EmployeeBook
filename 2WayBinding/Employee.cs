using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WayBinding
{
    public class Employee
    {
        private const string TEXT_FILE_NAME = "EmployeeTextFile.txt";
        
        public string Name { get; set; }
        public string Title { get; set; }
        //Method to get single dummy employee
        /* public static Employee GetEmployee()
        {
            var employee = new Employee()
            {
                Name = "Susan",
                Title = "CEO"
            };
            return employee;
        }
        */
        public async static Task<ICollection<Employee>> GetEmployees()
        {
            var employees = new List<Employee>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            //Debug.WriteLine(fileContent);
            //return null;
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var employee = new Employee
                {
                    Name = lineParts[0],
                    Title = lineParts[1]
                };
                employees.Add(employee);
            }
            return employees;
        }



        /// <summary>
        /// Write Employee to file
        /// </summary>
        /// <param name="employee">the employee object to write</param>
        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name},{employee.Title}";
            //var employeeData= employee.Name + "," + employee.Title;
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, employeeData);
        }
        public static async Task DeleteByName(string searchName)
        {
            var employeeLists = await GetEmployees();
            string newEmployees = string.Empty;
            foreach(var employee in employeeLists)
            {
                if(searchName != employee.Name)
                {
                    var employeeData = $"{employee.Name},{employee.Title}";
                    newEmployees = $"{newEmployees}\n{employeeData}";
                }
            }
            //await FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, newEmployees);
           await FileHelper.WriteAfterDeleteAsync(TEXT_FILE_NAME, newEmployees);
        }
        //Logic Coding Experiments
        /* 
        public static void WriteUpdateEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name},{employee.Title}";
            //var employeeData= employee.Name + "," + employee.Title;
            FileHelper.WriteUpdateFileAsync(TEXT_FILE_NAME, employeeData);
        }
        */
/*
        public static async void RemoveEmployee(string Name)
        {

            var employees = new List<Employee>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME2);
            //Debug.WriteLine(fileContent);
            //return null;
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var lineParts = line.Split(',');
                if (lineParts.Contains(Name))
                    continue;
                var employee = new Employee
                {
                    Name = lineParts[0],
                    Title = lineParts[1]
                };
                employees.Add(employee);

                WriteUpdateEmployee(employee);

            }
            */


        }
    }



