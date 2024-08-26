using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class GetTaskDto : IDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string ProjectName { get; set; }
        public string AssignedEmployeeName { get; set; }
        public string TaskStatusName { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool ManagerApproval { get; set; }
    }
}
