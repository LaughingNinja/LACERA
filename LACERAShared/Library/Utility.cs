using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using LACERAShared.Models;

namespace LACERAShared.Library
{
    public class Utility
    {
        public List<Employee> ParseCSVEmployee(string documentToParse, object dtoClass = null)
        {
            DateTime birthDateOut;
            DateTime dateHiredOut;
            Decimal salaryOut;
            List<Employee> employeeList = new List<Employee>();
            using (var sr = new StreamReader(documentToParse))
            {

                //Skip the first line
                sr.ReadLine();

                //Read the rest
                string readLine;
                while ((readLine = sr.ReadLine()) != null)
                {
                    Employee employee = new Employee();
                    string[] employeeImport = readLine.Split(',');
                    //Strip quotes
                    employee.Name = employeeImport[0].Replace("“", string.Empty).Replace("”", string.Empty);

                    //Validate records

                    //Birthdate
                    if (employeeImport[1] == null || !DateTime.TryParse(employeeImport[1], out birthDateOut))
                    {
                        employee.IsInvalid = true;
                    }
                    else
                    {
                        employee.Birthdate = Convert.ToDateTime(employeeImport[1]);
                    }
                    //Salary
                    if (employeeImport[2] == null || !Decimal.TryParse(employeeImport[2], out salaryOut) ||
                        Convert.ToDecimal(employeeImport[2]) <= 0)
                    {
                        employee.IsInvalid = true;
                    }
                    else
                    {
                        employee.Salary = Convert.ToDecimal(employeeImport[2]);
                    }
                    //DateHired
                    if (employeeImport[3] == null || !DateTime.TryParse(employeeImport[3], out dateHiredOut))
                    {
                        employee.IsInvalid = true;
                    }
                    else
                    {
                        employee.DateHired = Convert.ToDateTime(employeeImport[3]);
                    }

                    employeeList.Add(employee);
                }

            }
            return employeeList;
        }
    }
}
