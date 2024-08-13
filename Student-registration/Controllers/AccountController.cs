using Microsoft.AspNetCore.Mvc;
using Mysqlx.Session;
using Student_registration.Models;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

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
        public IActionResult Rgister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rgister(Rgistermodel model)
        {
            if (ModelState.IsValid)
            {
                var encryptedPassword = common.Security.Hash(model.Password);
                Generic obj = new Generic();
                int userExistsResult = obj.UserAlreadyExit(model.Email);

                if (userExistsResult == 0)
                {
                    bool rgistrationResult = obj.Rgister(model, encryptedPassword);
                    if (rgistrationResult)
                    {
                        ViewBag.Message = "Account Rgistered successfully!";
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
                    
                   string userid = "mohammadzafar12555@gmail.com";
                   string Password = "exmu rkcj pxor yupo";
                   string SMTPPort = "587";
                   string Host = "smtp.gmail.com";
                    string subject = "Reset password";
                    string encryptedemail = common.Security.Encrypt(model.Email);
                    var body = "<a href='" + Url.Action("ResetPassword", "Account", new { email = encryptedemail }, "https") + "'>Reset Password</a>";
                    string To =model.Email;
                    //EmailManager objs=new EmailManager();
                    EmailManager.SendEmail(userid, subject, body, To, Password, userid, SMTPPort, Host);
                    //EmailManager.SendEmailAsync(From, subject, body, To, SMTPPort, Host);
                    //EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);
                    ViewBag.Message = "Password reset link has been sent to your email.";
                    return View();
        }
        [HttpGet]
        public IActionResult testaction()
        {
            return View();

        }
        [HttpPost]
        public IActionResult testaction( string email)
        {
            string encryptedemail = common.Security.Encrypt(email);
            string Decrypt= common.Security.Decrypt(encryptedemail);
            if (encryptedemail == null)
            {
                ViewBag.Message = "Encrypted Email successfully!";
                return View(email);
            }
            else
            {
                ViewBag.Message = "Encrypted Email not successfully";
                return View(email);
            }

           
        }
        [HttpGet]
        public IActionResult ResetPassword(string email)
        {
            string Decrypt = common.Security.Decrypt(email);
            ViewBag.Email = Decrypt; 

            Generic obj = new Generic();
            int userExistsResult = obj.UserAlreadyExit(Decrypt);
            if (userExistsResult == 1)
            {
                return View();
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult ResetPassword(string email, string Password)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                bool result = obj.Updatepassword(email, Password);

                if (result)
                {
                    TempData["updated"] = "Password update successfully ";
                }
                else
                {
                    ViewBag.Message = "Failed to update the password.";
                }
            }
            return View();
        }


    }
}
