using Business_Layer.Repositories.Interface;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipperController : ControllerBase
	{
		private readonly IShipperRepository _shipperRepository;

		public ShipperController(IShipperRepository shipperRepository)
		{
			_shipperRepository = shipperRepository;
		}

		// GET: api/<ShipperController>
		[HttpGet("GetAllShippers")]
		//[Authorize(Roles = UserRole.Admin)]
		public async Task<APIResponseModel> GetAllShipper()
		{
			try
			{
				var result = await _shipperRepository.GetAllShipper();
				return new APIResponseModel()
				{
					code = 200,
					message = "Get successful",
					IsSuccess = true,
					Data = result,
				};
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		

	}
}
