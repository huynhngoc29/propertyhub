using PropertyHub.Api.Data;
using PropertyHub.Api.DTOs;
using PropertyHub.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace PropertyHub.Api.Services;

public class UnitService : IUnitService
{
    private readonly AppDbContext _context;
    public UnitService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Unit>> GetAllAsync()
    {
        return await _context.Units.ToListAsync();
    }
    public async Task<Unit?> GetByIdAsync(int id)
    {
        return await _context.Units.FindAsync(id);
    }
    public async Task<Unit?> CreateAsync(CreateUnitDto dto)
    {
        var property = await _context.Properties.FindAsync(dto.PropertyId);
        if (property == null)
        {
            return null;
        }
        var unit = new Unit
        {
            Code = dto.Code,
            Price = dto.Price,
            Status = dto.Status,
            PropertyId = dto.PropertyId,
            ThumbnailUrl = dto.ThumbnailUrl
        };
        _context.Units.Add(unit);
        await _context.SaveChangesAsync();
        return unit;
    }
    public async Task<Unit?> UpdateAsync(int id, UpdateUnitDto dto)
    {
        var unit = await _context.Units.FindAsync(id);
        if (unit == null)
        {
            return null;
        }
        var property = await _context.Properties.FindAsync(dto.PropertyId);
        if (property == null)
        {
            return null;
        }
        unit.Code = dto.Code;
        unit.Price = dto.Price;
        unit.Status = dto.Status;
        unit.ThumbnailUrl = dto.ThumbnailUrl;

        await _context.SaveChangesAsync();
        return unit;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var unit = await _context.Units.FindAsync(id);
        if (unit == null)
        {
            return false;
        }
        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();
        return true;
    }
}