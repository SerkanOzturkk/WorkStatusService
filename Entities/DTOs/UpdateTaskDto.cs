using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class UpdateTaskDto : IDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int ProjectId { get; set; }
        public int AssignedEmployeeId { get; set; }
        public string Status { get; set; }
        public bool ManagerApproval { get; set; }
    }
}