using Business_Layer.Repositories.Interfaces;
using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.Shipper;
using Data_Layer.ResourceModel.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ShipperController : ControllerBase
	{
		private readonly IShipperService _shipperservice;

		public ShipperController(IShipperService shipperservice)
		{
			_shipperservice = shipperservice;
		}

		// GET: api/<ShipperController>
		[HttpGet("GetAllShippers")]
		//[Authorize(Roles = UserRole.Admin)]
		public async Task<APIResponseModel> GetAllShipper()
		{
			try
			{
				var result = await _shipperservice.GetShipperAsync();
				return result;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpPost("createShipper")]
		public async Task<APIResponseModel> CreateShipper ([FromBody] ShipperCreateVM model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					var errors = ModelState.Values.SelectMany(v => v.Errors)
								  .Select(e => e.ErrorMessage).ToList();
					return new APIResponseModel
					{
						code = 400,
						Data = errors,
						IsSuccess = false,
						message = string.Join(";", errors)
					};
				}

				var result = await _shipperservice.CreateShipperAccount(model);
				return result;

			}
			catch (Exception ex)
			{
				return new APIResponseModel()
				{
					code = StatusCodes.Status400BadRequest,
					message = ex.Message,
					Data = ex,
					IsSuccess = false
				};
			}
		}
		[HttpGet("GetShipperById")]
		//[Authorize(Roles = UserRole.Admin)]
		public async Task<APIResponseModel> GetShipperById(string id)
		{

			var result = await _shipperservice.GetShipperById(id);
			if (result != null)
			{
				return new APIResponseModel
				{
					code = 200,
					IsSuccess = true,
					Data = result,
				};
			}
			return new APIResponseModel
			{
				code = 404,
				IsSuccess = false ,
				message = "user doesn't exist."
			};
		}
		}
	}
