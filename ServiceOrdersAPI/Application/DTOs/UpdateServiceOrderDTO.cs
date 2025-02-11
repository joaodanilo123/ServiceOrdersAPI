using System.ComponentModel.DataAnnotations;
using ServiceOrderManagement.Domain.Enums;
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