using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class TeamDetailDto : IDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamLeaderName { get; set; }
    }
}
