using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vidly.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create(int id)
        {
            return Content("Yes am creating it now "+ id);
        }
        [Route("game/release/{year}/{sortby}")]
        public ActionResult GameRelease(int? year, string sortBy)
        {
            if (!year.HasValue)
                year = 2000;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("We are searching {0} by sort {1}", year, sortBy));
        }

        


    }
}