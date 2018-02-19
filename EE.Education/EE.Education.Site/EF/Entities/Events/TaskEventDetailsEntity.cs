using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities.Events
{
    public class TaskEventEntity : EventEntity
    {
        public virtual TaskEventDetailsEntity Details { get; set; }
    }
    
    public class TaskEventDetailsEntity : EventDetailsEntity
    {
        [ForeignKey(nameof(EventId))]
        public virtual TaskEventEntity Event { get; set; }
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual TaskEntity Task { get; set; }

        [Required]
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime? DecisionDate { get; set; }
        public int? ResultId { get; set; }
        [ForeignKey(nameof(ResultId))]
        public virtual TaskEventResultEntity Result { get; set; }
    }

    public class TaskEventResultEntity : IDomainEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PointCount { get; set; }
        public string Comment { get; set; }
    }
}