
namespace IslamicFace.Presentation.API.Controllers.v1.UploadsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController(ISender _sender, IFileService fileService) : ControllerBase
    {
        [HttpPut("Update-Profile-Cover")]
        [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProfileCover([FromForm] UpdateProfileCoverModel request)
        {

            var UploadResult = await fileService.UploadProfileCoverAsync(request.Image);

            if (UploadResult is null)
                return Result.Failure(Error.BadRequest("Image upload error", "Profile image not uploaded")).ToActionResult();

            if (UploadResult.IsFailure)
                return UploadResult.ToActionResult();

            Result result = await _sender.Send(new UpdateProfileCoverCommand(request.userId, UploadResult.Value.ImagePathWithoutRootPath, UploadResult.Value.CurrentRootPath));

            return result.ToActionResult();
        }

        [HttpPut("Update-Profile-Image")]
        [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProfileImage([FromForm] UpdateProfileImageModel request)
        {

            var UploadResult = await fileService.UploadProfileImageAsync(request.Image);

            if (UploadResult is null)
                return Result.Failure(Error.BadRequest("Image upload error", "Profile image not uploaded")).ToActionResult();

            if (UploadResult.IsFailure)
                return UploadResult.ToActionResult();

            Result result = await _sender.Send(new UpdateProfileImageCommand(request.userId, UploadResult.Value.ImagePathWithoutRootPath, UploadResult.Value.CurrentRootPath));

            return result.ToActionResult();

        }
    }
}
