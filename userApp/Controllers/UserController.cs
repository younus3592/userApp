using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using userApp.Models;

namespace userApp.Controllers
{
    public class UserController : Controller
    {
        UsersService userService = new UsersService();
        // GET: User
        public ActionResult UsersList()
        {
            UsersModel model = new UsersModel();

            model.UsersList =  userService.GetUsersList();

            return View(model);
        }
        public ActionResult UserEditor(int? userId)
        {
            UserEditorModel model = userService.PrepareUserEditorModel(userId);

            return View(model);
        }
    }
}