using EPiServer.Core;
using EPiServer.Web;
using Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Models.Pages
{
  /// <summary>
  /// Represents contact details for a contact person
  /// </summary>
  [SiteContentType(
        GUID = "F8D47655-7B50-4319-8646-3369BA9AF05B",
        GroupName = SiteGlobal.GroupNames.Specialized)]
  [SiteImageUrl(SiteGlobal.StaticGraphicsFolderPath + "page-type-thumbnail-contact.png")]
  public class ContactPage : SitePageData, IContainerPage
  {
    [Display(GroupName = SiteGlobal.GroupNames.Contact)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference Image { get; set; }

    [Display(GroupName = SiteGlobal.GroupNames.Contact)]
    public virtual string Phone { get; set; }

    [Display(GroupName = SiteGlobal.GroupNames.Contact)]
    [EmailAddress]
    public virtual string Email { get; set; }
  }
}
