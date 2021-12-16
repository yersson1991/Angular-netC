using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        public int EmployeId { get; set; }
        public string  EmployeeName { get; set; }
        public string Departament { get; set; }
        public int DateOfJoining { get; set; }
        public string PhotoName { get; set; }

    }
}
