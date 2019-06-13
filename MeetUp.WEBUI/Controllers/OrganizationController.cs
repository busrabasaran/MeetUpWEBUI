using MeetUp.BLL;
using MeetUp.Entity;
using MeetUp.WEBUI.Filter;
using MeetUp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetUp.WEBUI.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationBLL organizationBLL = new OrganizationBLL();
        ParticipantBLL participantBLL = new ParticipantBLL();
        UserBLL userBLL = new UserBLL();
        MessagesBLL messagesBLL = new MessagesBLL();

        // GET: Organizasyon
        public ActionResult Index()
        {
            return View();
        }

        [MyAuthenticationFilter]
        public ActionResult OrganizationsList()
        {
            List<Organizations> organizations = organizationBLL.GetOrganizations();
            return View(organizations);
        }

        [MyAuthenticationFilter]
        public ActionResult OrganizationDetail(int id)
        {
            Organizations organization = organizationBLL.GetOrganization(id);
            Session["Organization"] = organization;
            OrganizationParticipantModel model = new OrganizationParticipantModel
            {
                organizations = organization
            };
            return View(model);
        }

        [MyAuthenticationFilter]
        public ActionResult AddOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrganization(Organizations organization)
        {
            Users users = Session["Login"] as Users;
            organization.UserID = users.UserID;

            organizationBLL.AddOrganization(organization);
            return RedirectToAction("OrganizationsList", "Organization");
        }

        [HttpPost]
        public ActionResult JoınOrganizations(OrganizationParticipantModel model)
        {
            Participants participant = new Participants();
            Users usr = Session["Login"] as Users;

            List<Participants> participants = participantBLL.GetParticipantOrganizations(usr.UserID);
            foreach (var item in participants)
            {
                if (usr.UserID == item.UserID && model.organizations.OrganizationID == item.OrganizationID)
                {
                    return RedirectToAction("OrganizationsList");
                }

            }
            participant.UserID = usr.UserID;
            participant.OrganizationID = model.organizations.OrganizationID;
            participant.NumberofPeople = model.ParticipantNumber;
            participant.Date = DateTime.Now;

            participantBLL.JoınOrganization(participant);
            return RedirectToAction("OrganizationsList", new { id = model.organizations.OrganizationID });
        }

        [MyAuthenticationFilter]
        public ActionResult MyOrganizationList()
        {
            Users usr = Session["Login"] as Users;
            List<Participants> myorganizations = participantBLL.GetParticipantOrganizations(usr.UserID);
            return View(myorganizations);
        }

        public ActionResult ParticipantOrganizationUpdate(int id)
        {
            Participants participant = participantBLL.GetParticipants(id);
            return View(participant);
        }

        [HttpPost]
        public ActionResult ParticipantOrganizationUpdate(Participants model)
        {
            Participants participant = participantBLL.GetParticipants(model.ParticipantID);
            participant.NumberofPeople = model.NumberofPeople;
            participant.Date = DateTime.Now;

            participantBLL.JoınOrganizationUpdate(participant);
            return RedirectToAction("MyOrganizationList");
        }

        public ActionResult ParticipantOrganizationDelete(int id)
        {
            participantBLL.DeleteParticipant(id);
            return RedirectToAction("MyOrganizationList");
        }

        public ActionResult ParticipantList()
        {
            Organizations organization = Session["Organization"] as Organizations;
            List<Participants> participantUsers = participantBLL.GetParticipantsList(organization.OrganizationID);
            return View(participantUsers);
        }

        public ActionResult MyMessagesList()
        {
            Users usr = Session["Login"] as Users;
            List<Messages> mymessages = messagesBLL.GetMessagesList(usr.UserID);
            return View(mymessages);
        }

        public ActionResult MessageDelete(int id)
        {
            messagesBLL.DeleteMessage(id);
            return RedirectToAction("MyMessagesList");
        }

        [MyAuthenticationFilter]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Messages message)
        {
            Users usr = Session["Login"] as Users;
            Organizations organization = Session["Organization"] as Organizations;

            message.FromUserID = usr.UserID;
            message.ToUserID = organization.UserID;
            message.Date = DateTime.Now;

            messagesBLL.AddMessage(message);
            return RedirectToAction("MyMessagesList");
        }

        public ActionResult MessageAnswer(int id)
        {
            Users user = Session["Login"] as Users;

            Messages message = messagesBLL.GetMessage(id);
            message.Body = "";

            if (message.ToUserID == user.UserID)
            {
                MessageModel model = new MessageModel
                {
                    ToUserID = message.ToUserID,
                    FromUserID = message.FromUserID,
                    Message = message.Body,
                    Mail=message.Users.Email
                };
                return View(model);
            }
            else
            {
                MessageModel model = new MessageModel
                {
                    ToUserID = message.ToUserID,
                    FromUserID = message.FromUserID,
                    Message = message.Body,
                    Mail = message.Users1.Email
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult MessageAnswer(MessageModel model)
        {
            Users toUser = userBLL.GetUser(model.Mail);
            Users fromUser = Session["Login"] as Users;

            Messages message = new Messages
            {
                Body = model.Message,
                ToUserID = toUser.UserID,
                FromUserID = fromUser.UserID,
                Date = DateTime.Now
            };

            messagesBLL.AddMessage(message);
            return RedirectToAction("MyMessagesList");
        }
    }
}