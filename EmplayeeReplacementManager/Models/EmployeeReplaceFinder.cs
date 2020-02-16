using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeReplacementManager.Models
{
    public class EmployeeReplaceFinder
    {
       
        public async Task<List<Employee>> LoadEmployees()
        {
            HttpClient client = new HttpClient();
            List<Employee> testList = new List<Employee>();
            HttpResponseMessage responseMessage = await client.GetAsync("https://portal.fastdev.se/api/test");
            if (responseMessage.IsSuccessStatusCode)
            {
                testList = await responseMessage.Content.ReadAsAsync<List<Employee>>();
            }
            return testList;
        }
 
        public Employee GetReplaceForEmployee(Employee employee) // переименовать
        {
            var employees = LoadEmployees().Result;
            employee = employees.Find(e => e.Name == employee.Name) ?? employee;
            employees.Remove(employee);
            return employees.OrderBy(e => e.Location == employee.Location)
                                .ThenBy(e => e.Tags.Intersect(employee.Tags ?? new List<string>()).Count()).LastOrDefault();
        }
    }
}