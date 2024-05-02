using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net3.Frontend.Controllers
{
    public class AdminController : Controller
    {
        Logic.Interfaces.IChannelManager _channelManager = new Logic.Classes.ChannelManager();
        Logic.Interfaces.IUserManager _userManager = new Logic.Classes.UserManager();
        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            try
            {
                ViewBag.ChannelList = _channelManager.GetAll();
                ViewBag.ChannelCount = _channelManager.GetAll().Count;
                ViewBag.UserList = _userManager.GetAll();
            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }

    }
}