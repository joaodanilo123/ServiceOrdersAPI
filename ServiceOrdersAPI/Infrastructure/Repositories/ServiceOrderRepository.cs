using Microsoft.EntityFrameworkCore;
using ServiceOrderManagement.Infrastructure.Data;
using ServiceOrdersManagement.Domain.Entities;
using ServiceOrdersManagement.Domain.Enums;
using ServiceOrdersManagement.Domain.Interfaces;

namespace ServiceOrderManagement.Infrastructure.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly AppDbContext _context;

        public ServiceOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceOrder> AddAsync(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Add(serviceOrder);
            await _context.SaveChangesAsync();
            return serviceOrder;
        }

        public async Task<IEnumerable<ServiceOrder>> GetAllAsync(OrderStatus? status = null, string? clientName = null)
        {
            var query = _context.ServiceOrders.AsQueryable();

            if (status.HasValue)
            {
                query = query.Where(so => so.Status == status.Value);
            }
            if (!string.IsNullOrEmpty(clientName))
            {
                query = query.Where(so => so.Client.Name.Contains(clientName));
            }

            return await query.ToListAsync();
        }

        public async Task<ServiceOrder> GetByIdAsync(int id)
        {
            return (await _context.ServiceOrders.FindAsync(id))!;
        }

        public async Task UpdateAsync(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Update(serviceOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Remove(serviceOrder);
            await _context.SaveChangesAsync();
        }
    }
}
