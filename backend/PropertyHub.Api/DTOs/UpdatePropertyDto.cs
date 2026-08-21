namespace PropertyHub.Api.DTOs;

public class UpdatePropertyDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ThumbnailUrl { get; set; }

}