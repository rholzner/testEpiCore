using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testEpiCore.EpiServer;

namespace testEpiCore.Pages
{
    public class AboutModel : PageModel
    {
        public AboutModel(IEpiServerInitialize epi)
        {
        var contentLoader = epi.GetInstance<IContentLoader>();
        contentLoader.TryGet(ContentReference.StartPage, out PageData pageData);
        var Name = pageData.Name;
        }
        public string Message { get; set; }

        public void OnGet()
        {
        Message = "Your application description page.";
        }
    }
}
