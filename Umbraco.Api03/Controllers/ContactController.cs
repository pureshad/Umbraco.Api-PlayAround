using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class ContactController : SurfaceController
    {
        public ActionResult RenderContact()
        {
            return PartialView("~/Views/Partials/Contact/Contact.cshtml");
        }
    }
}