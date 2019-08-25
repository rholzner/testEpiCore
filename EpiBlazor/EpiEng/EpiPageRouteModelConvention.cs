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
    model.Selectors.Add(new SelectorModel()
    {
      AttributeRouteModel = new AttributeRouteModel
      {
        Template = item.URLSegment,
        Name = item.ContentGuid.ToString(),
      }
    });
    }
    }
    }
    }
  }
}
