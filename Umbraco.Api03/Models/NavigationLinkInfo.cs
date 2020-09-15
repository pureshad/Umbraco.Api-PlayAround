using System;
using System.Collections.Generic;
using System.Linq;

namespace Umbraco.Api03.Models
{
    public class NavigationLinkInfo
    {
        public NavigationLinkInfo(string text = null, string url = null, bool newWindow = false, string title = null)
        {
            Text = text;
            Url = url;
            NewWindow = newWindow;
            Title = title;
        }
        public NavigationLinkInfo()
        {

        }
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public string Target { get { return NewWindow ? "_blank" : null; } }
        public string Title { get; set; }
    }

    public class NavigationList
    {
        public NavigationList(NavigationLinkInfo link)
        {
            Link = link;
        }
        public NavigationList()
        {

        }
        public string Text { get; set; }
        public NavigationLinkInfo Link { get; set; }
        public List<NavigationList> NavItems { get; set; }

        public bool HasSubNavigation { get { return NavItems != null && NavItems.Any() && NavItems.Count > 0; } }
    }
}

