using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories.Interfaces
{
    public interface IShipperRepository
    {
        Task<List<ShipperVM>> GetAllShipper();
        Task<APIResponseModel> ChangeToShipper(string userId);

    }
}
