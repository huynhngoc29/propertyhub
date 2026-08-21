using Microsoft.AspNetCore.Mvc;
using PropertyHub.Api.Services;
using PropertyHub.Api.DTOs;
namespace PropertyHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService _propertyService;

    public PropertiesController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var properties = await _propertyService.GetAllAsync();
        return Ok(properties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var property = await _propertyService.GetByIdAsync(id);
        if (property == null)
        {
            return NotFound();
        }
        return Ok(property);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreatePropertyDto dto)
    {
        var property = await _propertyService.CreateAsync(dto);
        return Ok(property);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePropertyDto dto)
    {
        var property = await _propertyService.UpdateAsync(id, dto);
        if (property == null)
        {
            return NotFound();
        }
        return Ok(property);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _propertyService.DeleteAsync(id);
        if (!delete)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpGet("{id}/detail")]
    public async Task<IActionResult> GetDetail(int id)
    {
        var property = await _propertyService.GetDetailAsync(id);

        if (property == null)
        {
            return NotFound();
        }

        var result = new PropertyDetailDto
        {
            Id = property.Id,
            Code = property.Code,
            Name = property.Name,
            Address = property.Address,
            City = property.City,
            Type = property.Type,
            Status = property.Status,
            Price = property.Price,

            Units = property.Units.Select(unit => new UnitDto
            {
                Id = unit.Id,
                Code = unit.Code,
                Price = unit.Price,
                Status = unit.Status,
                PropertyId = unit.PropertyId
            }).ToList()
        };

        return Ok(result);
    }
}