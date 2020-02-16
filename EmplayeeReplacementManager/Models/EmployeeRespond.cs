using EmployeeReplacementManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeReplacementManager.Models
{
    public class EmployeeRespond
    {
        [Required(ErrorMessage = "Введите свое имя")]
        public string EmployeeName { get; set; }

        //[Required(ErrorMessage = "Введите дату начала отпуска")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Дата начала отпуска должна быть актуальной")]
        public DateTime ? VacationStartDate { get; set; }

        [Required(ErrorMessage = "Введите дату конца отпуска")]
        [DataType(DataType.Date)]
        public DateTime ? VacationEndDate { get; set; }
    }
}
