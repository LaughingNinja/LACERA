using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LACERAShared;
using LACERAShared.Library;
using LACERAShared.Models;
using System.IO;

namespace LACERAConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a CSV document argument.");
                return;
            }
            string documentToParse = String.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), @"\CSV\", args[0]);
            Utility util = new Utility();
            List<Employee> employeeList =  util.ParseCSVEmployee(documentToParse);
            foreach(Employee employee in employeeList)
            {
                Console.WriteLine("Name:{0} Birthdate:{1} Salary:{2} DateHired:{3} IsInvalid:{4}", 
                    employee.Name, employee.Birthdate.HasValue ? ((DateTime)employee.Birthdate).Date.ToString("d") : "N/A", 
                    employee.Salary, 
                    employee.DateHired.HasValue ? ((DateTime)employee.DateHired).Date.ToString("d") : "N/A", employee.IsInvalid);
            }

        }
    }
}
