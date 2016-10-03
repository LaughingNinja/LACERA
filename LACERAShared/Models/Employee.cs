using System;
using System.Collections.Generic;
using System.Text;

namespace LACERAShared.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public Decimal? Salary { get; set; }
        public DateTime? DateHired { get; set; }
        public Boolean IsInvalid { get; set; }
    }
}
