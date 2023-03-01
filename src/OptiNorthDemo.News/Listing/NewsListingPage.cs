namespace OptiNorthDemo.News.Listing;

using System.ComponentModel.DataAnnotations;

using EPiServer.Core;
using EPiServer.DataAnnotations;

using OptiNorthDemo.Core;
using OptiNorthDemo.Core.Blocks;
using OptiNorthDemo.Core.Pages;

[ContentType(
    DisplayName = "News Listing Page",
    Description = "A page for listing and filtering news articles.",
    GUID = "422CF9C1-1F28-4CC2-8FDE-E50208944460",
    GroupName = GroupNames.Content)]
public class NewsListingPage : SitePageData
{
    [Display(
        Name = "Additional Content",
        Description = "A content area that allows blocks that have been specifically designed as content.",
        GroupName = GroupNames.Content,
        Order = 120)]
    [AllowedTypes(typeof(IContentBlock))]
    public virtual ContentArea? AdditionalContent { get; set; }
}