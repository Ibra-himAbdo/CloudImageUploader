namespace CloudImageUploader.Api.Models;

public class ProfilePicture : BaseEntity
{
    public Guid UserId { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
    public DateTime DateAdded { get; set; }
    public string? PublicId { get; set; }
}