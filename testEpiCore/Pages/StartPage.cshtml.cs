using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testEpiCore.EpiServer;

namespace testEpiCore.Pages
{
    public class StartPageModel : PageModel
    {
        private readonly IContentLoader contentLoader;
        public Models.Pages.StartPage EpiPage { get; set; }
        public StartPageModel(IEpiServerInitialize epi)
        {
            contentLoader = epi.GetInstance<IContentLoader>();

        }
        public void OnGet()
        {
            EpiPage = contentLoader.Get<Models.Pages.StartPage>(ContentReference.StartPage);
        }
    }
}
