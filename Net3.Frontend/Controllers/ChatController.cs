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
using Microsoft.Ajax.Utilities;

namespace Net3.Frontend.Controllers
{
    public class ChatController : Controller
    {
        Logic.Interfaces.IChannelManager _channelManager = new Logic.Classes.ChannelManager();
        Logic.Interfaces.IMessageManager _messageManager = new Logic.Classes.MessageManager();
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
                return View("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult ViewMessages(string channelId)
        {
            try
            {
                var msgs = _messageManager.GetChannelMessages(channelId);
                ViewBag.Messages = msgs;
                GetUserChannels();
                Session["SelectedChannel"] = channelId;
            }
            catch (Exception)
            {
                return View("Index");
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
                return View("Index");
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
                return View("Index");
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
                return View("Index");
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {

            try
            {
                var channelId = Session["SelectedChannel"] as string;
                if (message.IsNullOrWhiteSpace())
                {
                    return ViewMessages(channelId);
                }
                MessageModel model = new MessageModel()
                {
                    ChannelID = channelId,
                    Content = message,
                    UserID = User.Identity.Name

                };
                _messageManager.SendChannelMessage(model);
                return ViewMessages(channelId);
            }
            catch (Exception)
            {
                return View("Index");
            }
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