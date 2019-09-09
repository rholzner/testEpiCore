using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace EpiBlazorAppServerSide.EpiEng
{
    public class EpiPageModel<T> : PageModel where T : IContent
    {
        public T epiPage { get; set; }
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IContentLoader contentLoader;

        public EpiPageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
        contentLoader = epi.GetInstance<IContentLoader>();
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        //CurrentPage = pages.FirstOrDefault(x => x.URLSegment == )
        }

        public void OnGet()
        {
        var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
        ad => ad.AttributeRouteInfo != null && !string.IsNullOrEmpty(ad.AttributeRouteInfo.Name) && !string.IsNullOrEmpty(ad.AttributeRouteInfo.Template)).Select(ad => new RouteModel
        {
            Name = ad.AttributeRouteInfo.Name.Split('_')[0],
            Template = ad.AttributeRouteInfo.Template
        });

        var path = routes.FirstOrDefault(x => x.Template == Request.Path.Value);
        var hasCurrentPage = contentLoader.TryGet(new Guid(path.Name), out T CurrentPage);

        epiPage = CurrentPage;
        }
    }

    public class RouteModel
    {
        public string Name { get; set; }
        public string ContentId { get; set; }
        public string Template { get; set; }
    }
}
