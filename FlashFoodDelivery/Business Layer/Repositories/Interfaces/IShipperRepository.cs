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
		Task<ShipperVM> GetShipperByUserId(string userId);
	}
}
