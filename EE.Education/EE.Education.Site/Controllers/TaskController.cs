using System;
using System.Linq;
using EE.Education.Site.EF;
using EE.Education.Site.EF.Entities.Events;
using EE.Education.Site.EF.Enums;
using EE.Education.Site.Models.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EE.Education.Site.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public JsonResult GetAll()
        {
            var tasks = new[]
            {
                new TaskItem { Name = "Трассировка автономных систем", Group = "Basic", Cost = 8 },
                new TaskItem { Name = "Сервер \"точного\" времени", Group = "Basic", Cost = 8 },
                new TaskItem { Name = "Сканер TCP и UDP портов", Group = "Basic", Cost = 5 },
                new TaskItem { Name = "Кэширующий DNS сервер", Group = "Dns", Cost = 20 },
                new TaskItem { Name = "SMTP клиент", Group = "Applications", Cost = 10 },
                new TaskItem { Name = "POP3 клиент", Group = "Applications", Cost = 10 },
                new TaskItem { Name = "HTTP proxy", Group = "Applications", Cost = 10 },
                new TaskItem { Name = "Использование HTTP API", Group = "Applications", Cost = 10 }
            };
            return Json(new { IsSuccess = true, Items = tasks});
        }
    }
}
