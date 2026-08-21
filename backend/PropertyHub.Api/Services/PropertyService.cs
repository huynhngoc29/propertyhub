using Microsoft.EntityFrameworkCore;
using PropertyHub.Api.Entities;
using PropertyHub.Api.Data;
using PropertyHub.Api.DTOs;
namespace PropertyHub.Api.Services;

public class PropertyService : IPropertyService
{
    private readonly AppDbContext _context;
    public PropertyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Property>> GetAllAsync()
    {
        return await _context.Properties.ToListAsync();
    }

    public async Task<Property?> GetByIdAsync(int id)
    {
        return await _context.Properties.FindAsync(id);
    }
    public async Task<Property> CreateAsync(CreatePropertyDto dto)
    {
        var property = new Property //lấy  dữ liệu từ dto tạo ra 1 object mới
        {
            Code = dto.Code,
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            Type = dto.Type,
            Status = dto.Status,
            Price = dto.Price,
            ThumbnailUrl = dto.ThumbnailUrl,
            CreatedAt = DateTime.UtcNow
        };
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<Property?> UpdateAsync(int id, UpdatePropertyDto dto)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return null;
        }
        property.Code = dto.Code;
        property.Name = dto.Name;
        property.Address = dto.Address;
        property.City = dto.City;
        property.Type = dto.Type;
        property.Status = dto.Status;
        property.Price = dto.Price;
        property.ThumbnailUrl = dto.ThumbnailUrl;
        await _context.SaveChangesAsync();
        return property;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return false;
        }
        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<Property?> GetDetailAsync(int id)
    {
        return await _context.Properties.Include(p => p.Units).FirstOrDefaultAsync(p => p.Id == id);
    }
}