namespace OptiNorthDemo.News.Article;

using System.ComponentModel.DataAnnotations;

using EPiServer.Core;
using EPiServer.DataAnnotations;

using OptiNorthDemo.Core;
using OptiNorthDemo.Core.Blocks;
using OptiNorthDemo.Core.Pages;

[ContentType(
    DisplayName = "News Article Page",
    Description = "A flexible news article page.",
    GUID = "DADC30C2-7F68-45F3-B279-FD4446B9B3CA",
    GroupName = GroupNames.Content)]
public class NewsArticlePage : SitePageData
{
    [Display(
        Name = "Display Published Date",
        GroupName = GroupNames.Content,
        Order = 100)]
    public virtual DateTime? DisplayPublishedDate { get; set; }

    [Display(
        Name = "Article Content",
        Description = "A content area that allows blocks that have been specifically designed as content.",
        GroupName = GroupNames.Content,
        Order = 110)]
    [AllowedTypes(typeof(IContentBlock))]
    public virtual ContentArea? ArticleContent { get; set; }

    [Display(
        Name = "Additional Content",
        Description = "A content area that allows blocks that have been specifically designed as content.",
        GroupName = GroupNames.Content,
        Order = 120)]
    [AllowedTypes(typeof(IContentBlock))]
    public virtual ContentArea? AdditionalContent { get; set; }
}