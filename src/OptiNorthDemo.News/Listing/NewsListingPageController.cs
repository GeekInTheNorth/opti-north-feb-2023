namespace OptiNorthDemo.News.Listing;

using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Web.Mvc;

using Microsoft.AspNetCore.Mvc;

using OptiNorthDemo.News.Article;

public sealed class NewsListingPageController : PageController<NewsListingPage>
{
    private readonly IClient _client;

    public NewsListingPageController(IClient client)
    {
        _client = client;
    }

    [HttpGet]
    public IActionResult Index(NewsListingPage currentPage)
    {
        var model = new NewsListingPageViewModel(currentPage)
        {
            Articles = GetArticles(currentPage)
        };

        return View(model);
    }

    private List<NewsArticlePage> GetArticles(NewsListingPage listingPage)
    {
        var ancestor = listingPage.ContentLink.ToReferenceWithoutVersion().ToString();

        return _client.Search<NewsArticlePage>()
                      .Filter(x => x.Ancestors().Match(ancestor))
                      .FilterForVisitor()
                      .Take(10)
                      .StaticallyCacheFor(TimeSpan.FromMinutes(5))
                      .GetContentResult()
                      .ToList();
    }
}