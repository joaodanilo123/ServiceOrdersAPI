using System.ComponentModel.DataAnnotations;
using ServiceOrdersManagement.Domain.Enums;

namespace ServiceOrderManagement.Application.DTOs
{
    public class UpdateServiceOrderDTO
    {
        [Required]
        public required string ServiceDescription { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}