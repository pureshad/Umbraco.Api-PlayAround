using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class TestController : SurfaceController
    {
        // GET: Test
        public ActionResult RenderTest()
        {
            return PartialView("~/Views/Partials/Home/_Test.cshtml");
        }
    }
}