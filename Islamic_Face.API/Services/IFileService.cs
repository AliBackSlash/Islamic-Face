namespace IslamicFace.Presentation.API.Services;

public interface IFileService
{
    Task<Result<string>> UploadProfileImageAsync(IFormFile file);
    Task<Result<List<string>>?> UploadPostImagesAsync(List<IFormFile> files);
}
