using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class AddTimeLogDto : IDto
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public DateTime Date { get; set; }
        public float HoursWorked { get; set; }
        public float OvertimeHours { get; set; }
    }
}
