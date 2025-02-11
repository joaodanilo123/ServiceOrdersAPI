using ServiceOrdersManagement.Domain.Entities;
using ServiceOrdersManagement.Domain.Enums;

namespace ServiceOrdersManagement.Domain.Interfaces
{
    public interface IServiceOrderRepository
    {
        Task<ServiceOrder> AddAsync(ServiceOrder serviceOrder);
        Task<IEnumerable<ServiceOrder>> GetAllAsync(OrderStatus? status = null, string? clientName = null);
        Task<ServiceOrder> GetByIdAsync(int id);
        Task UpdateAsync (ServiceOrder serviceOrder);
        Task DeleteAsync(ServiceOrder serviceOrder);
    }
}
