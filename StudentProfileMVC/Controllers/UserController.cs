using Microsoft.AspNetCore.Mvc;
using StudentProfileMVC.Models;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace StudentProfileMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult View(string firstname, string lastname, string group, int grade1, int grade2, int grade3, string[] programmingLanguages)
        {
            var user = new User();
            var viewModel = new UserViewModel { User = user };

            if (!checkString(firstname, 15, 2))
            {
                viewModel.Errors.Add("Error with firstname: Must be between 2 and 15 characters.");
            }
            else
            {
                user.Firstname = firstname;
            }

            if (!checkString(lastname, 15, 2))
            {
                viewModel.Errors.Add("Error with lastname: Must be between 2 and 15 characters.");
            }
            else
            {
                user.Lastname = lastname;
            }

            if (!checkString(group, 7, 5))
            {
                viewModel.Errors.Add("Error with group: Must be between 5 and 7 characters.");
            }
            else
            {
                user.Group = group;
            }

            if (!checkInts(grade1, 12, 0))
            {
                viewModel.Errors.Add("Error with Grade 1: Must be between 0 and 12.");
            }
            else
            {
                user.Grade1 = grade1;
            }

            if (!checkInts(grade2, 12, 0))
            {
                viewModel.Errors.Add("Error with Grade 2: Must be between 0 and 12.");
            }
            else
            {
                user.Grade2 = grade2;
            }

            if (!checkInts(grade3, 12, 0))
            {
                viewModel.Errors.Add("Error with Grade 3: Must be between 0 and 12.");
            }
            else
            {
                user.Grade3 = grade3;
            }

            if (programmingLanguages is null)
            {
                viewModel.Errors.Add("Error with programming languages");
            }
            else
            {
                user.ProgrammingLanguages = programmingLanguages.ToList();
            }

            return View(viewModel); 
        }

        private bool checkString(string name, int max, int min) 
        {
            return (name.Length <= max && name.Length >= min);
        }

        private bool checkInts(int grade, int max, int min)
        {
            return (grade <= max && grade >= min);
        }
    }


}

