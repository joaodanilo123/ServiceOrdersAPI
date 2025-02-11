using ServiceOrderManagement.Application.DTOs;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Domain.Entities;
using ServiceOrdersManagement.Domain.Enums;

namespace ServiceOrderManagement.Application.Interfaces
{
    public interface IServiceOrderService
    {
        Task<ServiceOrder> CreateServiceOrderAsync(CreateServiceOrderDTO dto);
        Task<IEnumerable<ServiceOrder>> GetAllServiceOrdersAsync(OrderStatus? status = null, string? clientName = null);
        Task<ServiceOrder> GetServiceOrderByIdAsync(int id);
        Task<ServiceOrder> UpdateServiceOrderAsync(int id, UpdateServiceOrderDTO dto);
        Task DeleteServiceOrderAsync(int id);
    }
}
