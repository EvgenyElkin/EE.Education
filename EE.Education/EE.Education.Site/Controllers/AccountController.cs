using System.Linq;
using EE.Education.Site.EF;
using EE.Education.Site.EF.Entities;
using EE.Education.Site.Infrastructure.Authentification;
using EE.Education.Site.Infrastructure.Repositories;
using EE.Education.Site.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EE.Education.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDataRepository _repository;

        public AccountController(IDataRepository repository, IAuthenticationService authenticationService)
        {
            _repository = repository;
            _authenticationService = authenticationService;
        }

        #region Аутентификация

        [HttpPost]
        public JsonResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {IsSuccess = false, Message = "Некорректные данные"});
            }
            var user = _repository.Get((UserEntity x) => 
                x.Email.ToLower() == model.Email.ToLower() &&
                x.Hash.ToLower() == model.PassHash.ToLower());

            if (user == null)
            {
                return Json(new {IsSuccess = false, Message = "Неверный пользователь или пароль"});
            }

            var principal = _authenticationService.GetClaim(user);
            var token = AuthHelper.CreateToken(principal);

            return Json(new
            {
                isSuccess = true,
                accessToken = token
            });
        }

        [HttpPost]
        public JsonResult Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsSuccess = false, Message = "Некорректные данные" });
            }
            var emails = _repository.Select<UserEntity>()
                .Select(x => x.Email.ToLower())
                .ToHashSet();
            if (emails.Contains(model.Email))
            {
                return Json(new { IsSuccess = false, Message = "Данный Email уже занят" });
            }

            var user = new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Email = model.Email,
                Hash = model.PassHash,
                IsTeacher = false
            };

            _repository.Add(user);
            _repository.Apply();

            var principal = _authenticationService.GetClaim(user);
            var token = AuthHelper.CreateToken(principal);

            return Json(new
            {
                isSuccess = true,
                accessToken = token
            });
        }

        #endregion

        //[HttpPost]
        //[Authorize]
        //public JsonResult CheckPrincipal()
        //{
        //    return Json(new
        //    {
        //        IsSuccess = true, 
        //        UserId = User.HasClaim("UserId", "1"),
        //        IsTeacher = User.HasClaim("IsTeacher", "True")
        //    });
        //}
    }
}
