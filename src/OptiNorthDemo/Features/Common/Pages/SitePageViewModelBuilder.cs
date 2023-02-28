﻿namespace OptiNorthDemo.Features.Common.Pages;

public abstract class SitePageViewModelBuilder<TContent, TModel> : ISitePageViewModelBuilder<TContent, TModel>
    where TContent : ISitePageData
    where TModel : ISitePageViewModel<TContent>
{
    protected TModel Model;

    protected SitePageViewModelBuilder()
    {
        Model = (TModel)Activator.CreateInstance(typeof(TModel), default(TContent))!;
    }

    public ISitePageViewModelBuilder<TContent, TModel> WithContent(TContent? content)
    {
        Model = (TModel)Activator.CreateInstance(typeof(TModel), content)!;

        return this;
    }

    public abstract TModel Build();
}
