namespace PropertyHub.Api.Entities;

public class Unit
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Status { get; set; } = string.Empty;

    public int PropertyId { get; set; }
    public string? ThumbnailUrl { get; set; }

    public Property Property { get; set; } = null!;
}