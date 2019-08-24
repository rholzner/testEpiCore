using EPiServer.DataAnnotations;

namespace Models
{
  /// <summary>
  /// Attribute used for site content types to set default attribute values
  /// </summary>
  public class SiteContentType : ContentTypeAttribute
  {
    public SiteContentType()
    {
    GroupName = SiteGlobal.GroupNames.Default;
    }
  }
}
