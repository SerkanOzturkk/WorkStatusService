using Core.Entities;


namespace Entities.Concrete
{
    public class Team : BaseEntity
    {

        public string TeamName { get; set; }

        public int? TeamLeaderId { get; set; } // Nullable çünkü bazı takımların lideri olmayabilir
        public Employee TeamLeader { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
