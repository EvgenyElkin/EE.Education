using System;
using System.Collections.Generic;
using EE.Education.Site.EF.Entities.Events;
using EE.Education.Site.EF.Enums;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities
{
    public class TaskEntity : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskTypes Type { get; set; }
        public int Cost { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Deadline { get; set; }
        public virtual ICollection<TaskEventDetailsEntity> TaskEvents { get; set; }
    }
}