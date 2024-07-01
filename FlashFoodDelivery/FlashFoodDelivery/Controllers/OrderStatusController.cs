using Business_Layer.Repositories.Interfaces;
using Business_Layer.Services.Interfaces;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.OrderStatusVM;
using Data_Layer.ResourceModel.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class OrderStatusController : ControllerBase
	{
		private readonly IOrderStatusService _odrerstatusService;

		public OrderStatusController(IOrderStatusService statusOrderStatus)
		{
			_odrerstatusService = statusOrderStatus;
		}

		[HttpPost("CreateOrderStatus")]
		//[Authorize(Roles = UserRole.Admin)]
		public async Task<IActionResult> CreateOrderStatus([FromBody] OrderStatusCreateVM model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					var errors = ModelState.Values.SelectMany(v => v.Errors)
								  .Select(e => e.ErrorMessage).ToList();
					return BadRequest(errors);

				}

				var result = _odrerstatusService.CreateOrderStatusAsync(model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST api/<ShipperController>
		[HttpGet("GetOrderStatusByShipperId")]
			//[Authorize(Roles = UserRole.Admin)]
			public async Task<IActionResult> GetOrderStatusByShipperId(string userId)
			{
				try
				{
					if (!ModelState.IsValid)
					{
						var errors = ModelState.Values.SelectMany(v => v.Errors)
									  .Select(e => e.ErrorMessage).ToList();
					return BadRequest(errors);
					}

					var result = _odrerstatusService.GetOrderStatusByShipperId(userId);
				return Ok(result);

				}
				catch (Exception ex)
				{
					return NotFound();
				}
			}

		[HttpPost("ChangeOrderStatus")]
		//[Authorize(Roles = UserRole.Admin)]
		public async Task<IActionResult> ChangeOrderStatus(string orderStatusId)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					var errors = ModelState.Values.SelectMany(v => v.Errors)
								  .Select(e => e.ErrorMessage).ToList();
					return BadRequest(errors);
				}

				var result = _odrerstatusService.ChangeOrderStatus(Guid.Parse(orderStatusId));
				return Ok(result);

			}
			catch (Exception ex)
			{
				return NotFound(ex);
			}
		}
	}
}
