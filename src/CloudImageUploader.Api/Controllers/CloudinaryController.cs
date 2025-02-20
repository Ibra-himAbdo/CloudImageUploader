namespace CloudImageUploader.Api.Controllers;

public class CloudinaryController : BaseApiController
{
    private readonly ICloudinaryService _cloudinaryService;

    public CloudinaryController(ICloudinaryService cloudinaryService)
    {
        _cloudinaryService = cloudinaryService;
    }

    [HttpPost("upload-image")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImageAsync([FromQuery] Guid userId, IFormFile file)
    {
        var image = await _cloudinaryService.UploadImageAsync(userId, file);
        if (image is null)
            return BadRequest();

        return Ok(image);
    }

    [HttpGet]
    public Guid GetGuid()
    {
        return Guid.NewGuid();
    }

}