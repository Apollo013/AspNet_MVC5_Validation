using AspNet_MVC5_Validation.Models;
using System.Diagnostics;
using System.Web.Mvc;

namespace AspNet_MVC5_Validation.Controllers
{
    public class UserController : Controller
    {
        Users registeredUsers;

        public UserController()
        {
            registeredUsers = new Users();
            registeredUsers.Add(new RegisterVM() { Name = "Henry", Email = "Henry@gmail.com" });
            registeredUsers.Add(new RegisterVM() { Name = "Mary", Email = "Mary@gmail.com" });
            registeredUsers.Add(new RegisterVM() { Name = "Phil", Email = "Philip@gmail.com" });
            registeredUsers.Add(new RegisterVM() { Name = "John", Email = "John@gmail.com" });
        }

        // GET: User
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                // Do whatever posting needs to be done here
                return View(new User() { Email = "Go Agaion" });

            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.RegisteredUsers = registeredUsers.Count;
            return View(new RegisterVM());
        }

        [HttpPost]
        public ActionResult Register(RegisterVM user)
        {
            if (ModelState.IsValid)
            {
                registeredUsers[user.Email] = user;
                ViewBag.RegisteredUsers = registeredUsers.Count;
                Debug.WriteLine($"{user.Email} - {registeredUsers.Count}");
                ModelState.Clear();
                return View(new RegisterVM());
            }
            else
            {
                Debug.WriteLine($"FAILED - {registeredUsers.Count}");
                return View();
            }

        }

        /// <summary>
        /// This is the method specified in the 'Remote' attribute for 'Email' property in 'RegisterVM' model
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EmailAlreadyExists(string email)
        {
            // Must return false if email already exists
            Debug.WriteLine(registeredUsers[email] == null);
            return Json(registeredUsers[email] == null);
        }

    }
}