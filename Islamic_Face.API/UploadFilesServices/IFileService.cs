using IslamicFace.Presentation.API.UploadFilesServices;

namespace IslamicFace.Presentation.API.Services;

public interface IFileService
{
    Task<Result<UploadResponse>> UploadProfileImageAsync(IFormFile file);
    Task<Result<UploadResponse>> UploadProfileCoverAsync(IFormFile file);
    Task<Result<List<string>>?> UploadPostImagesAsync(List<IFormFile> files);
}
