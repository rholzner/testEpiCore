using EpiBlazorAppServerSide.EpiEng;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EpiBlazorAppServerSide.Pages
{
    public class NewsPageModel : EpiPageModel<Models.Pages.NewsPage>
    {
        public NewsPageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(epi, actionDescriptorCollectionProvider)
        {

        }
    }
}
