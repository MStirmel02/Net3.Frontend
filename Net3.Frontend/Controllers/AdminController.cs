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
        Logic.Interfaces.IMessageManager _messageManager = new Logic.Classes.MessageManager();
        Logic.Interfaces.IUserManager _userManager = new Logic.Classes.UserManager();
        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            try
            {
                //ViewBag.ChannelList = _channelManager.GetAll();
                //ViewBag.UserList = _
            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }

    }
}