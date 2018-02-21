using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities
{
    public class TaskGroupEntity : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual CourseEntity Course { get; set; }
        public virtual ICollection<TaskEntity> Tasks { get; set; }
    }
}