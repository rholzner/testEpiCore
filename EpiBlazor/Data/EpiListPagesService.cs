using EpiBlazor.EpiEng;
using EPiServer;
using EPiServer.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpiBlazor.Data
{
    public class EpiListPagesService
    {
        private readonly IContentLoader contentLoader;
        public EpiListPagesService(IEpiServerInitialize epiServerInitialize)
        {
        contentLoader = epiServerInitialize.GetInstance<IContentLoader>();
        }

        public Task<List<PageListItem>> LoadALlPages()
        {
        var pages = contentLoader.GetDescendents(ContentReference.StartPage);
        var result = new List<PageListItem>();
        foreach (var item in pages)
        {
        var page = contentLoader.Get<PageData>(item);


        if (page.ContentLink != ContentReference.StartPage || page.ParentLink != ContentReference.StartPage)
        {

        var parents = contentLoader.GetAncestors(page.ContentLink);
        var url = page.URLSegment;
        foreach (var parent in parents)
        {
        if (parent is PageData pageData && pageData.ContentLink != ContentReference.StartPage)
        {
        
        url = pageData.URLSegment + "/" + url;
        }
        }
        if (!result.Any(x => x.Key == page.ContentLink.ToString()))
        {
        result.Add(new PageListItem() { Key = page.ContentLink.ToString(), Name = page.Name, Type = page.PageTypeName, Url = url });
        }
        }
        }
        return Task.FromResult(result);

        }
    }
}
