using Core.Entities;

namespace Entities.Concrete
{
    public class TaskStatus : BaseEntity
    {
        public string StatusName { get; set; }  // Durum adı, örneğin "Completed", "InProgress"
        public ICollection<Task> Tasks { get; set; }  // Bu durumla ilişkili görevler
    }
}