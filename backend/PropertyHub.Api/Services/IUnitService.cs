using PropertyHub.Api.Entities;
using PropertyHub.Api.DTOs;
namespace PropertyHub.Api.Services;

public interface IUnitService
{
    Task<List<Unit>> GetAllAsync();
    Task<Unit?> GetByIdAsync(int id);
    Task<Unit?> CreateAsync(CreateUnitDto dto);
    Task<Unit?> UpdateAsync(int id, UpdateUnitDto dto);
    Task<bool> DeleteAsync(int id);
}