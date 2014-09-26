using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Data;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
  public class HomeController : Controller
  {
    private IMailService _mail;
    private IMessageBoardRepository _repo;

      public HomeController(IMailService mail, IMessageBoardRepository repo)
    {
        _repo = repo;
        _mail = mail;
    }
    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
        var topics = _repo.GetTopics().OrderByDescending(p => p.Created).Take(25).ToList();
      return View(topics);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    [HttpPost]
    public ActionResult Contact(ContactModel model)
    {
        var message = string.Format("Comment From: {1}{0}Email: {2}{0}Website: {3}{0}Comment: {4}{0}", 
            Environment.NewLine, model.Name, model.Email, model.Website, model.Comment);
        var svc = new MailService();
        if(_mail.SendMail("justin@babalan.com", "noreply@babalan.com", "Message from site", message))
        {
            ViewBag.MailSent = true;
        }
        return View();
    }
      [Authorize]
    public ActionResult MyMessages()
    {
        return View();
    }

  }
}
