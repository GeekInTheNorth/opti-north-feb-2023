namespace OptiNorthDemo.News.Listing;

using OptiNorthDemo.Core.Pages;
using OptiNorthDemo.News.Article;

public partial class NewsListingPageViewModel : SitePageViewModel<NewsListingPage>
{
    public NewsListingPageViewModel(NewsListingPage currentPage) : base(currentPage)
    {
    }

    public List<NewsArticlePage> Articles { get; set; } = new();
}