using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LACERAShared.Library;
using LACERAShared.Models;

namespace LACERASharedTests
{
    [TestFixture]
    public class LACERASharedNunitTests
    {
        [Test]
        public void ParseCSVEmployeeTest()
        {
            // Arrange
            Utility util = new Utility();

            // Act
            string documentToParse = @"C:\Users\glackerman\Documents\visual studio 2015\Projects\LACERA\LACERAConsoleApp\CSV\lacera.csv";
            List<Employee> employeeList = util.ParseCSVEmployee(documentToParse);

            // Assert
            Assert.IsNotNull(employeeList);
        }
    }
}
