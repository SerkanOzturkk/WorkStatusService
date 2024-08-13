using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entities;


namespace Entities.Concrete
{
    public class Team : BaseEntity
    {

        public string TeamName { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
