using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testEpiCore.EpiServer;

namespace testEpiCore.Pages
{
    public class ArticlePage : PageModel
    {
        public Models.Pages.ArticlePage epiPage { get;set;}
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IContentLoader contentLoader;
        public ArticlePage(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            contentLoader = epi.GetInstance<IContentLoader>();
            var pages = new List<Models.Pages.ArticlePage>();
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            //CurrentPage = pages.FirstOrDefault(x => x.URLSegment == )
        }
        public string Message { get; set; }

        public void OnGet()
        {
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
            ad => ad.AttributeRouteInfo != null).Select(ad => new RouteModel
            {
                Name = ad.AttributeRouteInfo.Name,
                Template = ad.AttributeRouteInfo.Template
            }).ToList();

            var path = routes.FirstOrDefault( x => x.Template == Request.Path.Value.Replace("/",""));
            var hasCurrentPage = contentLoader.TryGet<Models.Pages.ArticlePage>(new Guid(path.Name), out Models.Pages.ArticlePage CurrentPage);
            epiPage = CurrentPage;
        }
    }
    public class RouteModel
    {
        public string Name { get; set; }
        public string Template { get; set; }
    }
}
