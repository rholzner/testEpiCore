using EpiBlazor.EpiEng;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EpiBlazor.Pages
{
    public class ArticlePageModel : EpiPageModel<Models.Pages.ArticlePage>
    {
        public ArticlePageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(epi,actionDescriptorCollectionProvider)
        {

        }
    }
}
