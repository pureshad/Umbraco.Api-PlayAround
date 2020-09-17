using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Web.Mvc;
using Umbraco.Api03.Models;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class SiteSharedLayoutController : SurfaceController
    {
        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/SharedLayout/Footer.cshtml");
        }
        public ActionResult RenderHeader()
        {
            List<NavigationList> navList = GetNavigationModel();
            return PartialView("~/Views/Partials/SharedLayout/Header.cshtml", navList);
        }

        public List<NavigationList> GetNavigationModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]);
            var pageInfo = Umbraco.Content(pageId);

            var nav = new List<NavigationList>()
            {
                //new NavigationList(new NavigationLinkInfo(pageInfo.Name, pageInfo.Url))
            };

            nav.AddRange(GetNavigationList(pageInfo));

            return nav;
        }

        public List<NavigationList> GetNavigationList(dynamic page)
        {
            List<NavigationList> navList = null;

            var subPages = page.Children.Where("Visible");
            if (subPages != null && subPages.Any())
            {
                navList = new List<NavigationList>();
                foreach (var subPage in subPages)
                {
                    var listItem = new NavigationList(new NavigationLinkInfo(subPage.Name, subPage.Url))
                    {
                        NavItems = GetNavigationList(subPage)
                    };

                    navList.Add(listItem);
                }
            }
            return navList;
        }

    }
}