using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EpiBlazor.EpiEng
{
    public class EpiPageModel<T> : PageModel where T : IContent
    {
        public T epiPage { get; set; }
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IContentLoader contentLoader;
        private readonly IContentVersionRepository contentVersionRepository;

        public EpiPageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
        contentLoader = epi.GetInstance<IContentLoader>();
        contentVersionRepository = epi.GetInstance<IContentVersionRepository>();
        var pages = new List<T>();
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        //CurrentPage = pages.FirstOrDefault(x => x.URLSegment == )
        }

        public void OnGet()
        {
        var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
        ad => ad.AttributeRouteInfo != null).Select(ad => new RouteModel
        {
            Name = ad.AttributeRouteInfo.Name.Split('_')[0],
            Template = ad.AttributeRouteInfo.Template
        }).ToList();

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
