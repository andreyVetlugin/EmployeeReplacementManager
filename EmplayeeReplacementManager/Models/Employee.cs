using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeReplacementManager.Models
{
    public class Employee
    {

        public string Name { get; set; }
        
        public string Location{ get; set; }

        public string PrimaryTechnology { get; set; }

        public List<string> Tags { get; set; }
        //public DateTime backForJob заменить на промежуток ??
    }
}
