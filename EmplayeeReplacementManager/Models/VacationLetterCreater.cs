using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeReplacementManager.Models
{
    public class VacationLetterCreater //constructor
    {
        public string GetLetterText(EmployeeRespond employeeRespond, Employee subtitute)
        {
            return $"Я, {employeeRespond.EmployeeName}, ухожу в отпуск с {employeeRespond.VacationStartDate} " +
                $"по {employeeRespond.VacationEndDate}. Меня Будет Заменять {subtitute.Name}";
        }// изменить тип 
    }
}
