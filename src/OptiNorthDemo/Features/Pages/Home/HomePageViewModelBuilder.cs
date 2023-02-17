namespace OptiNorthDemo.Features.Pages.Home;

using OptiNorthDemo.Features.Common.Pages;

public class HomePageViewModelBuilder : SitePageViewModelBuilder<HomePage, HomePageViewModel>, IHomePageViewModelBuilder
{
    public override HomePageViewModel Build()
    {
        // TODO : Add custom property building here.  Expected to include catering, events and news.
        // Abstract builder instantiates this model.
        return Model;
    }
}