using EPiServer.Core;

namespace Models.Pages
{
  public interface IHasRelatedContent
  {
    ContentArea RelatedContentArea { get; }
  }
}
