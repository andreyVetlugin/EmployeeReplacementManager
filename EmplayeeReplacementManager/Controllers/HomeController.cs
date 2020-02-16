using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeReplacementManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeReplacementManager.Controllers
{
    public class HomeController : Controller
    {

        private EmployeeReplaceFinder employeeFinder;
        private VacationLetterCreater vacationLetterCreater;


      

        public HomeController(EmployeeReplaceFinder finder, VacationLetterCreater  letterCreater)
        {
            employeeFinder = finder;
            vacationLetterCreater = letterCreater;
        }

        public IActionResult Index()
        {
            var test3 = employeeFinder.GetReplaceForEmployee(new Employee { Name = "dfefwefwef Kopylov" });
            return View();
        }

        [HttpPost]
        public IActionResult Index(EmployeeRespond respond)
        {

            if (respond.VacationEndDate < respond.VacationStartDate)
            {
                ModelState.AddModelError(nameof(respond.VacationEndDate), "Дата окончания отпуска должна быть не меньше даты начала отпуска");
            }

            if (ModelState.IsValid)
            {
                var leavingEmployee = new Employee { Name = respond.EmployeeName };
                var subtitute = employeeFinder.GetReplaceForEmployee(leavingEmployee);

                var letterText = vacationLetterCreater.GetLetterText(respond, subtitute);
                return View("Letter",letterText);
            }
            return View();
        }
    }
}
