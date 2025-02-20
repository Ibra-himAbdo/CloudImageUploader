namespace CloudImageUploader.Api.Models;

public class AppUser : BaseEntity
{
    public string? Username { get; set; }
    public string? Email { get; set; }

    // and so on ...
}