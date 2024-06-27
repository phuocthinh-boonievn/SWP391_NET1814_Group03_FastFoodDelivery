using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.Shipper;
using Data_Layer.ResourceModel.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories.Interfaces
{
    public interface IShipperRepository : IGenericRepository<User>
	{
		Task<IEnumerable<ShipperVM>> GetShippeAccountAll();
		Task<APIResponseModel> CreateShipperAccount(ShipperCreateVM model);
		Task<IEnumerable<ShipperVM>> GetShippeAccountById(string id);
	}
}
