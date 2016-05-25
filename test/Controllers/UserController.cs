using System.Collections.Generic;
using System.Web.Mvc;
using test.Business;
using test.Data.Models;
using test.ViewModels;

namespace test.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            using (BusinessContext businessContext = new BusinessContext())
            {
                User[] users = businessContext.UserManager.GetUsers();
                foreach (User user in users)
                {
                    model.Add(new UserViewModel
                    {
                        ID = user.ID,
                        Name = user.Name,
                        Email = user.Email,
                    });
                }
            }

            return this.View(model);
        }

        [HttpGet, /*OutputCache(Duration = 30, VaryByParam = "id")*/]
        public ActionResult Get(int id)
        {
            UserViewModel model = null;
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(id);
                model = new UserViewModel
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                };
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel userModel)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(userModel.ID);
                user.Name = userModel.Name;
                user.Email = userModel.Email;
                businessContext.UserManager.UpdateUser(user);
            }

            return RedirectToAction("Get", new { id = userModel.ID });
        }
    }
}