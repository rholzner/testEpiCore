using System.Web;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;
using EPiServer.Core;
using Models.Pages;

namespace EpiserverSiteAlloy.Models.ViewModels
{
    public class ContactBlockModel
    {
        [UIHint(UIHint.Image)]
        public ContentReference Image { get; set; }
        public string Heading { get; set; }
        public string LinkText { get; set; }
        public IHtmlString LinkUrl { get; set; }
        public bool ShowLink { get; set; }
        public ContactPage ContactPage { get; set; }
    }
}
