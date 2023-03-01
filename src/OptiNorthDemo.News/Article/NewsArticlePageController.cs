namespace OptiNorthDemo.News.Article;

using EPiServer.Web.Mvc;

using Microsoft.AspNetCore.Mvc;

public sealed class NewsArticlePageController : PageController<NewsArticlePage>
{
    [HttpGet]
    public IActionResult Index(NewsArticlePage currentPage)
    {
        var model = new NewsArticlePageViewModel(currentPage);

        return View(model);
    }
}