using System.Linq;
using EE.Education.Site.EF.Entities;
using EE.Education.Site.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EE.Education.Site.Controllers
{
    public class TaskController : Controller
    {
        private readonly IDataRepository _repository;

        public TaskController(IDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetAll()
        {
            var tasks = _repository.Select<TaskGroupEntity>()
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
