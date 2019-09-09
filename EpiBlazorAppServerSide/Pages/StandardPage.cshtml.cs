using EpiBlazorAppServerSide.EpiEng;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EpiBlazorAppServerSide.Pages
{
    public class StandardPageModel : EpiPageModel<Models.Pages.StandardPage>
    {
        public StandardPageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(epi, actionDescriptorCollectionProvider)
        {

        }
    }
}