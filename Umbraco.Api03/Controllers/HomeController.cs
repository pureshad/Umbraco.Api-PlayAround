using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class HomeController : SurfaceController
    {
        // GET: Home
        public ActionResult RenderSectionBanner()
        {
            return PartialView("~/Views/Partials/Home/Banner.cshtml");
        }

        public ActionResult RenderSectionEveryProject()
        {
            return PartialView("~/Views/Partials/Home/EveryProject.cshtml");
        }

        public ActionResult RenderSectionOurAwards()
        {
            return PartialView("~/Views/Partials/Home/OurAwards.cshtml");
        }
        public ActionResult RenderSectionLatestWorks()
        {
            return PartialView("~/Views/Partials/Home/LatestWorks.cshtml");
        }
        public ActionResult RenderSectionTeam()
        {
            return PartialView("~/Views/Partials/Home/Team.cshtml");
        }
    }
}