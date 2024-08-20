using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class UpdateEmployeeDto : IDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int TeamId { get; set; }
    }
}
