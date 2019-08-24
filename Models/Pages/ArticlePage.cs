
namespace Models.Pages
{
  /// <summary>
  /// Used primarily for publishing news articles on the website
  /// </summary>
  [SiteContentType(
        GroupName = SiteGlobal.GroupNames.News,
        GUID = "AEECADF2-3E89-4117-ADEB-F8D43565D2F4")]
  [SiteImageUrl(SiteGlobal.StaticGraphicsFolderPath + "page-type-thumbnail-article.png")]
  public class ArticlePage : StandardPage
  {

  }
}
