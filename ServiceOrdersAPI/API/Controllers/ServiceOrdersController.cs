using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderManagement.Application.DTOs;
using ServiceOrderManagement.Application.Interfaces;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Domain.Enums;

namespace ServiceOrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrdersController : ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;

        public ServiceOrdersController(IServiceOrderService serviceOrderService)
        {
            _serviceOrderService = serviceOrderService;
        }

        // POST: api/ServiceOrders
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody] CreateServiceOrderDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOrder = await _serviceOrderService.CreateServiceOrderAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }

        // GET: api/ServiceOrders
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] OrderStatus? status, [FromQuery] string clientName)
        {
            var orders = await _serviceOrderService.GetAllServiceOrdersAsync(status, clientName);
            return Ok(orders);
        }

        // GET: api/ServiceOrders/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _serviceOrderService.GetServiceOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // PUT: api/ServiceOrders/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceOrderDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedOrder = await _serviceOrderService.UpdateServiceOrderAsync(id, dto);
                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/ServiceOrders/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceOrderService.DeleteServiceOrderAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
