using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyTracker.Models.Home;

namespace TourneyTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new IndexModel();
            model.TestList = new TestListModel();
            model.TestList.List.Add(new TestListModelItem
                {
                    id = 1,
                    text = "one"
                });
            model.TestList.List.Add(new TestListModelItem
            {
                id = 2,
                text = "two"
            });
            return View(model);
        }

        public ActionResult AddTestItem(TestListModel TestList, int id, string text)
        {
            TestList.List.Add(new TestListModelItem
            {
                id = id,
                text = text
            });
            return PartialView("~/Views/Home/EditorTemplates/TestListModel.cshtml", TestList);
        }
    }
}