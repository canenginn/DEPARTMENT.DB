﻿using DEPARTMENT.WEB.Business;
using DEPARTMENT.WEB.Models;
using DEPARTMENT.WEB.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace DEPARTMENT.WEB.Controllers
{
    public class LoginController : Controller
    {

        public LoginController()
        {
          

        }
        public JsonResult SignIn(LoginUser user)
        {
            var json = new LoginBusiness().Login(user).Result;
            if (json!=null){
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.SerialNumber, json.token),
                    new Claim(ClaimTypes.Name, json.nameSurname),
                    new Claim(ClaimTypes.Role, json.userTypeId.ToString()),
                    new Claim(ClaimTypes.Gender, json.departmentId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, json.username),
                    new Claim(ClaimTypes.Actor, json.Department.name),
                    new Claim(ClaimTypes.Sid, json.UserType.type),
                    new Claim(ClaimTypes.GroupSid, json.id.ToString()),

                };
                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                HttpContext.SignInAsync(principal);
                return Json("Ok");
            }
         
            return Json("Error");
       
        }
        public async Task<IActionResult> SignOut()
        {

            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
