namespace IslamicFace.Presentation.API.Services;

public class FileService(IWebHostEnvironment _env, IHttpContextAccessor _httpContextAccessor) : IFileService
{

    private async Task<Result<string>?> SaveFileAsync(IFormFile file, string folder)
    {
        if (file == null || file.Length == 0)
            return null;

        try
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var uploadPath = Path.Combine(_env.WebRootPath, folder);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);


            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (_env.IsDevelopment())
            {
                return filePath; 
            }

            var request = _httpContextAccessor.HttpContext!.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            return Result.Success($"{baseUrl}/{folder}/{fileName}");
        }
        catch (Exception ex)
        {
            return Result.Failure<string>(new Error("Upload image Error", ex.Message, ErrorType.InternalServer));
        }

        
    }

    public async Task<Result<string>?> UploadProfileImageAsync(IFormFile file)
    {
        return await SaveFileAsync(file, "profile-images");
    }

    public async Task<Result<List<string>?>> UploadPostImagesAsync(List<IFormFile> files)
    {
        var urls = new List<string>();

        foreach (var file in files)
        {
            var url = await SaveFileAsync(file, "post-images");
            if (url != null)
                urls.Add(url.Value);
        }

        return urls;
    }
}
