namespace CloudImageUploader.Api.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> options)
    {
        var cloudinaryService = options.Value;
        var account = new Account(
            cloudinaryService.CloudName,
            cloudinaryService.ApiKey,
            cloudinaryService.ApiSecret);

        _cloudinary = new Cloudinary(account);
    }

    public async Task<ProfilePicture?> UploadImageAsync(Guid userId, IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length > 0)
        {
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream)
            };
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }

        if (uploadResult is null)
            return null;

        return new ProfilePicture
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            PublicId = uploadResult.PublicId,
            Url = uploadResult.SecureUrl.ToString(),
            DateAdded = DateTime.UtcNow,
            Description = $"Profile photo for user {userId}"
        };
    }
}