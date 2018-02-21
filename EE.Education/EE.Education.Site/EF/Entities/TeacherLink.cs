using System.ComponentModel.DataAnnotations.Schema;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.EF.Entities
{
    public class TeacherLink : IEntity
    {
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual CourseEntity Course { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual UserEntity Teacher { get; set; }
    }
}