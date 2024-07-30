using Microsoft.AspNetCore.Mvc;
using Student_registration.Models;
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
        public IActionResult Signin(Signin modl)
        {
            ModelState.AddModelError("Password", "Invaild username or password");
            return View(modl);
            //return RedirectToAction("Index", "Home");


        }
        [HttpGet]
        public IActionResult Rgister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Rgister(Rgistermodel models)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic(); // Create generic object
                int userExistsResult = obj.UserAlreadyExit(models.Email);
               
                

                if (userExistsResult == 0)

                {
                    bool registrationResult = obj.Register(models);
                    if (registrationResult)
                    {
                        ViewBag.Message = "Account Registered successfully!";
                        return View(models);
                    }
                    else
                    {
                        ViewBag.Message = "Failed!";
                        return View(models);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", " Email already exists");
                    return View(models);
                }
            }

            return View(models);
        }



    }
}
