using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class EmployeeDetailDto : IDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string TeamName { get; set; }
    }
}
