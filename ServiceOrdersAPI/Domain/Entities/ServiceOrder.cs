using ServiceOrdersManagement.Domain.Enums;

namespace ServiceOrdersManagement.Domain.Entities
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public required Client Client { get; set; }
        public required string ServiceDescription { get; set; }
        public decimal Value { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public ServiceOrder()
        {
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Open;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Finalized && Status != OrderStatus.Finalized)
            {
                CompletedAt = DateTime.UtcNow;
            }
            Status = newStatus;
        }
    }
}
