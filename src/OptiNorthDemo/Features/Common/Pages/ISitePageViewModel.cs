namespace OptiNorthDemo.Features.Common.Pages;

public interface ISitePageViewModel<out TContent>
    where TContent : ISitePageData
{
    TContent? CurrentPage { get; }
}
