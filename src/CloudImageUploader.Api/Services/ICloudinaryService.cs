namespace CloudImageUploader.Api.Services;

public interface ICloudinaryService
{
    Task<ProfilePicture?> UploadImageAsync(Guid userId, IFormFile file);
}