using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE.Education.Site.EF.Entities.Events;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities
{
    public class UserEntity : IDomainEntity
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsTeacher { get; set; }

        public virtual ICollection<EventEntity> Events { get; set; }
    }
}
