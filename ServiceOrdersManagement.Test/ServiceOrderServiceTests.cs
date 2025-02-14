using Moq;
using ServiceOrderManagement.Application.Services;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Domain.Entities;
using ServiceOrdersManagement.Domain.Interfaces;

namespace ServiceOrderManagement.Tests
{
    public class ServiceOrderServiceTests
    {
        private readonly Mock<IServiceOrderRepository> _repositoryMock;
        private readonly ServiceOrderService _service;

        public ServiceOrderServiceTests()
        {
            _repositoryMock = new Mock<IServiceOrderRepository>();
            _service = new ServiceOrderService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateServiceOrderAsync_ValidDTO_ReturnsServiceOrder()
        {
            
            var createDto = new CreateServiceOrderDTO
            {
                ClientName = "John Doe",
                ClientDocument = "12345678900",
                ClientEmail = "john@example.com",
                ClientPhone = "123456789",
                ServiceDescription = "Test service",
                Value = 100.50m
            };

            
            _repositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<ServiceOrder>()))
                .ReturnsAsync((ServiceOrder so) =>
                {
                    so.Id = 1;
                    return so;
                });

            
            var result = await _service.CreateServiceOrderAsync(createDto);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("John Doe", result.Client.Name);
        }

    }
}