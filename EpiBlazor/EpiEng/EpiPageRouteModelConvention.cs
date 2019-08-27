using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EpiBlazor.EpiEng
{
    public class EpiPageRouteModelConvention : IPageRouteModelConvention
    {
        private readonly EpiServerInitialize _epiCore;
        public EpiPageRouteModelConvention(EpiServerInitialize epiCore)
        {
        _epiCore = epiCore;
        }
        public void Apply(PageRouteModel model)
        {

        var contentLoader = _epiCore.GetInstance<IContentLoader>();
        var pages = new List<PageData>();
        foreach (var contentReference in contentLoader.GetDescendents(ContentReference.StartPage))
        {
        var hasPage = contentLoader.TryGet(contentReference, out PageData pageData);
        if (hasPage)
        {
        pages.Add(pageData);
        }
        }
        var gruppedPages = pages.GroupBy(x => x.PageTypeName);


        foreach (var gruppe in gruppedPages)
        {
        if (model.ViewEnginePath.EndsWith(gruppe.Key))
        {

        var versions = new List<string>();
        foreach (var item in gruppe)
        {
        if (item.ContentLink != ContentReference.StartPage || item.ParentLink != ContentReference.StartPage)
        {

        var parents = contentLoader.GetAncestors(item.ContentLink);
        var url = item.URLSegment;
        foreach (var parent in parents)
        {
        if (parent is PageData pageData && pageData.ContentLink != ContentReference.StartPage)
        {

        url = pageData.URLSegment + "/" + url;
        }
        }
        
        var selector = new SelectorModel()
        {
            AttributeRouteModel = new AttributeRouteModel
            {
                Template = url,
                Name = item.ContentGuid.ToString(),
            }
        };

        if (!model.Selectors.Contains(selector))
        {
        model.Selectors.Add(selector);

        }



        }
        }
        }
        }
        }
    }
}
