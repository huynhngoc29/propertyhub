using Microsoft.AspNetCore.Mvc;
using PropertyHub.Api.DTOs;
using PropertyHub.Api.Services;

namespace PropertyHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnitsController : ControllerBase
{
    private readonly IUnitService _unitService;
    public UnitsController(IUnitService unitService)
    {
        _unitService = unitService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var units = await _unitService.GetAllAsync();
        var result = units.Select(unit => new UnitDto
        {
            Id = unit.Id,
            Code = unit.Code,
            Price = unit.Price,
            Status = unit.Status,
            PropertyId = unit.PropertyId
        }).ToList();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var unit = await _unitService.GetByIdAsync(id);
        if (unit == null)
        {
            return NotFound();
        }
        var result = new UnitDto
        {
            Id = unit.Id,
            Code = unit.Code,
            Price = unit.Price,
            Status = unit.Status,
            PropertyId = unit.PropertyId
        };
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateUnitDto dto)
    {
        var unit = await _unitService.CreateAsync(dto);
        if (unit == null)
        {
            return BadRequest("Property does not exist.");
        }
        var result = new UnitDto
        {
            Id = unit.Id,
            Code = unit.Code,
            Price = unit.Price,
            Status = unit.Status,
            PropertyId = unit.PropertyId
        };
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUnitDto dto)
    {
        var unit = await _unitService.UpdateAsync(id, dto);
        if (unit == null)
        {
            return NotFound();
        }
        var result = new UnitDto
        {
            Id = unit.Id,
            Code = unit.Code,
            Price = unit.Price,
            Status = unit.Status,
            PropertyId = unit.PropertyId
        };
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _unitService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}