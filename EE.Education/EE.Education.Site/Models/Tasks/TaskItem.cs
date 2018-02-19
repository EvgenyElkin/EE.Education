using System.ComponentModel;

namespace EE.Education.Site.Models.Tasks
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int Cost { get; set; }
    }
}
