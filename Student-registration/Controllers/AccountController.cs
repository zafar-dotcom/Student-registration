using Microsoft.AspNetCore.Mvc;
using Mysqlx.Session;
using Student_registration.Models;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;

namespace Student_registration.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(Signin model)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                int userExistResult = obj.UserExistOrNot(model);

                if (userExistResult == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Username or Password is not correct");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Rgistermodel model)
        {
            if (ModelState.IsValid)
            {
                var encryptedPassword = common.Security.Hash(model.Password);
                Generic obj = new Generic();

                int userExistsResult = obj.UserAlreadyExit(model.Email);

                if (userExistsResult == 0)
                {
                    bool registrationResult = obj.Register(model, encryptedPassword);
                    if (registrationResult)
                    {
                        ViewBag.Message = "Account Registered successfully!";
                        return View(model);
                    }
                    else
                    {
                        ViewBag.Message = "Failed!";
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                bool userExists = obj.UserAlreadyExit(model.Email) > 0;

                if (userExists)
                {
                    
                   string userid = "mohammadzafar12555@gmail.com";
                   string Password = "exmu rkcj pxor yupo";
                   string SMTPPort = "587";
                   string Host = "smtp.gmail.com";
                    string subject = "Reset password";
                    var lnkHref = "<a href='" + Url.Action("ResetPassword", "ForgtPassword", new { email = "test", code = "test" }, "https") + "'>Reset Password</a>";

                    string body = lnkHref;
                    string To =model.Email;
                    //EmailManager objs=new EmailManager();
                    EmailManager.SendEmail(userid, subject, body, To, Password, userid, SMTPPort, Host);
                    //EmailManager.SendEmailAsync(From, subject, body, To, SMTPPort, Host);
                    //EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);
                    ViewBag.Message = "Password reset link has been sent to your email.";
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "Email does not exist");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
