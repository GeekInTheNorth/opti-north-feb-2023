namespace OptiNorthDemo.Features.Blocks.Image;

public interface IImageBlockViewModelBuilder
{
    IImageBlockViewModelBuilder WithBlock(ImageBlock? block);

    ImageBlockViewModel? Build();
}
