using EpiBlazorAppServerSide.EpiEng;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EpiBlazorAppServerSide.Pages
{
    public class ArticlePageModel : EpiPageModel<Models.Pages.ArticlePage>
    {
        public ArticlePageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(epi, actionDescriptorCollectionProvider)
        {

        }
    }
}
