using System.Linq;
using EE.Education.Site.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EE.Education.Site.Controllers
{
    public class TaskController : Controller
    {
        private readonly EducationContext _context;

        public TaskController(EducationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var tasks = _context
                .TaskGroups
                .Include(x => x.Tasks)
                .ToArray()
                .Select(x => new
                {
                    GroupName = x.Name,
                    Tasks = x.Tasks.Select(t => new
                    {
                        t.Name,
                        t.Cost
                    })
                });

            return Json(new { IsSuccess = true, Items = tasks});
        }
    }
}
