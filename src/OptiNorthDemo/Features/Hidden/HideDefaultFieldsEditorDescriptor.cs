namespace OptiNorthDemo.Features.Hidden
{
    using EPiServer.Cms.Shell.Extensions;
    using EPiServer.Shell.ObjectEditing;
    using EPiServer.Shell.ObjectEditing.EditorDescriptors;

    [EditorDescriptorRegistration(EditorDescriptorBehavior = EditorDescriptorBehavior.PlaceLast,
        TargetType = typeof(ContentArea))]
    public class HideDefaultContentAreasEditorDescriptor : HideDefaultFieldsEditorDescriptor
    {
    }

    [EditorDescriptorRegistration(EditorDescriptorBehavior = EditorDescriptorBehavior.PlaceLast,
        TargetType = typeof(DateTime?))]
    public class HideDefaultDateTimesEditorDescriptor : HideDefaultFieldsEditorDescriptor
    {
    }

    public class HideDefaultFieldsEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);

            var contentType = metadata.FindOwnerContent()?.GetOriginalType()?.Name;
            var propertyName = metadata.PropertyName;
            if (ShouldHideField(contentType, propertyName))
            {
                metadata.ShowForEdit = false;
            }
        }

        private static bool ShouldHideField(string? contentType, string? propertyName)
        {
            var hiddenFields = new List<Tuple<string, string>>
            {
                new("NewsArticlePage", "AdditionalContent"),
                new("NewsArticlePage", "DisplayPublishedDate")
            };

            return hiddenFields.Any(x =>
                string.Equals(x.Item1, contentType, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Item2, propertyName)
            );
        }
    }

}
