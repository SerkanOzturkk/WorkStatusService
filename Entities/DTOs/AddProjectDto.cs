using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class AddProjectDto : IDto
    {
        public string ProjectName { get; set; }
        public int TeamId { get; set; }
    }
}