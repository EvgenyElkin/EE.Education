using System.Collections.Generic;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities
{
    public class CourseEntity : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StudentLink> Students { get; set; }
        public virtual ICollection<TeacherLink> Teachers { get; set; }
        public bool IsActive { get; set; }
    }
}