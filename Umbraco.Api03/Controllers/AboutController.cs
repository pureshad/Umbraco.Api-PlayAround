using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class AboutController : SurfaceController
    {
        public ActionResult RenderAbout()
        {
            return PartialView("~/Views/Partials/About/About.cshtml");
        }
    }
}