using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities.Events
{
    public abstract class EventEntity : IDomainEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; }
        public DateTime? Date { get; set; }
    }

    public abstract class EventDetailsEntity : IEntity
    {
        [Key]
        public int EventId { get; set; }
    }
}