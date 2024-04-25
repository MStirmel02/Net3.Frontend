using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Net3.Frontend.Logic;
using Net3.Frontend.DataObjects.Models;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;
using System.Data.Entity.Core.Metadata.Edm;
using Microsoft.AspNet.SignalR;

namespace Net3.Frontend.Controllers
{
    public class ChatController : Controller
    {
        Logic.Interfaces.IChannelManager _channelManager = new Logic.Classes.ChannelManager();
        Logic.Interfaces.IMessageManager _messageManager = new Logic.Classes.MessageManager();
        IHubContext<ChatHub> _hubContext;
        public ChatController() 
        {
            
        }
        // GET: Chat
        public ActionResult Index()
        {
            GetUserChannels();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChannelRequestModel model)
        {

            try
            {
                model.Channel = new ChannelModel()
                {
                    ChannelId = Request["createchannelid"],
                    ChannelHash = Logic.Classes.HelpManager.HashSha256(Request["createchannelpassword"])
                };
                model.UserId = User.Identity.Name;
                _channelManager.CreateChannel(model);
                GetUserChannels();
            }
            catch (Exception)
            {

                throw;
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult View(string channelId)
        {
            try
            {
                //ViewBag.MessageList = _messageManager.GetChannelMessages(channelId);

                _hubContext.Groups.Add

            }
            catch (Exception)
            {
                throw;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Join(ChannelRequestModel model)
        {
            try
            {
                model.Channel = new ChannelModel()
                {
                    ChannelId = Request["joinchannelid"],
                    ChannelHash = Logic.Classes.HelpManager.HashSha256(Request["joinchannelpassword"])
                };
                model.UserId = User.Identity.Name;
                _channelManager.JoinChannel(model);
                GetUserChannels();
            }
            catch (Exception)
            {

                throw;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Leave(string channelId)
        {
            try
            {
                ChannelRequestModel request = new ChannelRequestModel
                {
                    Channel = new ChannelModel
                    {
                        ChannelId = channelId
                    },
                    UserId = User.Identity.Name
                };
                _channelManager.LeaveChannel(request);
                GetUserChannels();
            }
            catch (Exception)
            {

                throw;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Delete(string channelId)
        {
            try
            {
                ChannelModel request = new ChannelModel
                {
                    ChannelId = channelId,
                    ChannelHash = ""
                };
                _channelManager.DeleteChannel(request);
                GetUserChannels();
            }
            catch (Exception)
            {

                throw;
            }
            return View("Index");
        }


        private void GetUserChannels()
        {
            try
            {
                ViewBag.Channels = _channelManager.GetUserChannels(User.Identity.Name);
            }
            catch (Exception)
            {
                ViewBag.Channels = new List<ChannelModel>();
            }
        }
    }
}