namespace IslamicFace.Domain.StaticFilesHelpersClasses;

public class StaticFilesSettings
{
    public required string ProfileImages_FileName { get; set; }
    public required string ProfileCovers_FileName { get; set; }
    public required string PostImages_FileName { get; set; }
    public required short MaxProfileImageSize { get; set; }
    public required short MaxProfileCoverSize { get; set; }
    public required short MaxPostImageSize { get; set; }
    public required List<string> AllowedImageExtensions { get; set; }

}
