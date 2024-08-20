using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class UpdateProjectDto : IDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int TeamId { get; set; }
    }
}
