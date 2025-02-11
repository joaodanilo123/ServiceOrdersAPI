using System.ComponentModel.DataAnnotations;

namespace ServiceOrdersManagement.Application.DTOs
{
    public record CreateServiceOrderDTO
    {
        [Required]
        public required string ClientName { get; init; }
        
        [Required]
        public required string ClientDocument { get; init; }
        
        [Required]
        [EmailAddress]
        public required string ClientEmail { get; init; }

        [Required]
        [Phone]
        public required string ClientPhone { get; init; }

        [Required]
        public required string ServiceDescription { get; init; }

        [Required]
        public decimal Value { get; init; }
    }
}
