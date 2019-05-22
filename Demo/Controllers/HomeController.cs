using LazyLoadInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LazyLoadInMVC.Controllers
{
    public class HomeController : Controller
    {
        public const int RecordsPerPage = 20;
        public List<Project> ProjectData;

        public HomeController()
        {
            ViewBag.RecordsPerPage = RecordsPerPage;            
        }

        public ActionResult Index()
        {
            return RedirectToAction("GetProjects");
        }        

        public ActionResult GetProjects(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {
                var projects = GetRecordsForPage(pageNum.Value);
                ViewBag.IsEndOfRecords = (projects.Any());
                return PartialView("_ProjectData", projects);
            }
            else
            {
                var projectRep = new ProjectRepository();
                ProjectData = projectRep.GetProjectList();

                ViewBag.TotalNumberProjects = ProjectData.Count;
                ViewBag.Projects = GetRecordsForPage(pageNum.Value);

                return View("Index");
            }
        }

        public List<Project> GetRecordsForPage(int pageNum)
        {
            var projectRep = new ProjectRepository();
            ProjectData = projectRep.GetProjectList();

            int from = (pageNum * RecordsPerPage);

            Thread.Sleep(5000);
            var tempList = (from rec in ProjectData
                            select rec).Skip(from).Take(5).ToList<Project>();

            return tempList;
        }
    }
}