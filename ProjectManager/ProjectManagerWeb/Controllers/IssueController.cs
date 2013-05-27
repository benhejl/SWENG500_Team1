using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagerLibrary.Models;



namespace ProjectManagerWeb.Controllers
{
    [Authorize]
    public class IssueController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public bool AddNewIssue()
        {
            return true;
        }

        public bool DeleteIssue()
        {
            return true;
        }

        public bool AddAssigneeToIssue()
        {
            return true;
        }

        public bool DeleteAssigneeFromIssue()
        {
            return true;
        }

        public bool EditIssueDetails()
        {
            return true;
        }

        public bool ViewIssueList()
        {
            return true;
        }
    }
}