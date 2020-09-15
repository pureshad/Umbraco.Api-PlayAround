using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class TypographyController : SurfaceController
    {
        public ActionResult RenderTypography()
        {
            return PartialView("~/Views/Partials/Typography/Typography.cshtml");
        }

    }
}