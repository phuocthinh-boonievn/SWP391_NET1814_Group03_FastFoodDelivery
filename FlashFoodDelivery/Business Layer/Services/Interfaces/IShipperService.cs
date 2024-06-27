using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel;
using Data_Layer.ResourceModel.ViewModel.Shipper;
using Data_Layer.ResourceModel.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IShipperService
    {
		Task<APIResponseModel> GetShipperAsync();
		Task<UserViewModel> GetShipperById(string id);
		Task<APIResponseModel> UpdateShipper(string id, ShipperCreateVM model);
		Task<APIResponseModel> DeleteShipper(string id);
	}
}
