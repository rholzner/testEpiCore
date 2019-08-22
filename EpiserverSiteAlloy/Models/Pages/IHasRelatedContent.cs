using EPiServer.Core;

namespace EpiserverSiteAlloy.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
