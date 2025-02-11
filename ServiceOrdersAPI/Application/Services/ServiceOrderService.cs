using ServiceOrderManagement.Application.DTOs;
using ServiceOrderManagement.Application.Interfaces;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Domain.Entities;
using ServiceOrdersManagement.Domain.Enums;
using ServiceOrdersManagement.Domain.Interfaces;

namespace ServiceOrderManagement.Application.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _repository;

        public ServiceOrderService(IServiceOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceOrder> CreateServiceOrderAsync(CreateServiceOrderDTO dto)
        {
            var client = new Client(dto.ClientName, dto.ClientDocument, dto.ClientEmail, dto.ClientPhone);
            var serviceOrder = new ServiceOrder
            {
                Client = client,
                ServiceDescription = dto.ServiceDescription,
                Value = dto.Value,
                Status = OrderStatus.Open,
                CreatedAt = DateTime.UtcNow
            };

            return await _repository.AddAsync(serviceOrder);
        }

        public async Task<IEnumerable<ServiceOrder>> GetAllServiceOrdersAsync(OrderStatus? status = null, string? clientName = null)
        {
            return await _repository.GetAllAsync(status, clientName);
        }

        public async Task<ServiceOrder> GetServiceOrderByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ServiceOrder> UpdateServiceOrderAsync(int id, UpdateServiceOrderDTO dto)
        {
            var serviceOrder = await _repository.GetByIdAsync(id);
            if (serviceOrder == null)
                throw new Exception("Service Order not found");

            // Atualiza a descrição do serviço
            serviceOrder.ServiceDescription = dto.ServiceDescription;

            // Atualiza o status e, se Finalized, preenche a data de conclusão
            if (dto.Status == OrderStatus.Finalized && serviceOrder.Status != OrderStatus.Finalized)
            {
                serviceOrder.CompletedAt = DateTime.UtcNow;
            }
            serviceOrder.Status = dto.Status;

            await _repository.UpdateAsync(serviceOrder);
            return serviceOrder;
        }

        public async Task DeleteServiceOrderAsync(int id)
        {
            var serviceOrder = await _repository.GetByIdAsync(id);
            if (serviceOrder == null)
                throw new Exception("Service Order not found");

            await _repository.DeleteAsync(serviceOrder);
        }
    }
}
