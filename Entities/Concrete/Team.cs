using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Team : IEntity
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
