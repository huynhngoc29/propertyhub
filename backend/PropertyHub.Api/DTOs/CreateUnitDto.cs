namespace PropertyHub.Api.DTOs;
public class CreateUnitDto
{
    public string Code { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Status { get; set; } = string.Empty;

    public int PropertyId { get; set; }

}