﻿namespace OptiNorthDemo.Features.Media;

using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

using OptiNorthDemo.Core;

[ContentType(
    DisplayName = "Document Content",
    GUID = "79DFA281-FDFB-4D9B-BF0F-E1627C6CFE6D",
    Description = "Document files can be uploaded in DOC, DOCX, XLS, XLSX, CSV, PPT, PPTX, PDF and TXT formats only.",
    GroupName = GroupNames.Content)]
[MediaDescriptor(ExtensionString = "doc,docx,xls,xlsx,csv,ppt,pptx,pdf,txt")]
public class DocumentContent : MediaData
{
}