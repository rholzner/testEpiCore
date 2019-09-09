using EpiBlazorAppServerSide.EpiEng;
using EPiServer;
using EPiServer.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpiBlazorAppServerSide.Data
{
    public class NavService
    {
        private readonly IContentLoader contentLoader;

        public NavService(IEpiServerInitialize epiServerInitialize)
        {
        contentLoader = epiServerInitialize.GetInstance<IContentLoader>();
        }
        public Task<List<NavItem>> GetNavLinks()
        {
        var pages = contentLoader.GetChildren<PageData>(ContentReference.StartPage);
        var result = new List<NavItem>();
        foreach (var item in pages)
        {
        result.Add(new NavItem() { Label = item.Name, Href = item.URLSegment });
        }
        return Task.FromResult(result);
        }

    }
}
