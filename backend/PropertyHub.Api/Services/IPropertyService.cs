using PropertyHub.Api.Entities;
using PropertyHub.Api.DTOs;

namespace PropertyHub.Api.Services;

public interface IPropertyService
{
    Task<List<Property>> GetAllAsync();
    Task<Property?> GetByIdAsync(int id);
    Task<Property> CreateAsync(CreatePropertyDto dto);
    Task<Property?> UpdateAsync(int id, UpdatePropertyDto dto);
    Task<bool> DeleteAsync(int id);
}