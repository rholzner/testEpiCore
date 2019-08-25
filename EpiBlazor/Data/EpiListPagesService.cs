using EpiBlazor.EpiEng;
using EPiServer;
using EPiServer.Core;
using System.Collections.Generic;
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
    result.Add(new PageListItem() { Name = page.Name,Type = page.PageTypeName, Url = page.URLSegment });
    }
    return Task.FromResult(result);
    }
  }
}
