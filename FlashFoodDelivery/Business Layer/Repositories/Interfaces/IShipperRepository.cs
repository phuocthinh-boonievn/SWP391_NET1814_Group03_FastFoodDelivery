using Data_Layer.ResourceModel.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories.Interface
{
	public interface IShipperRepository
	{
		Task<List<ShipperVM>> GetAllShipper();
		Task<ShipperVM> GetShipperById(Guid id);
		Task<ShipperVM> GetShipperByUserId(string userId);
		Task<bool> AddShipper(ShipperVM shipperVM);
		Task<bool> DeleteShipperById(Guid id);
		Task<bool> UpdateShipper(ShipperVM shipperVM);
	}
}
