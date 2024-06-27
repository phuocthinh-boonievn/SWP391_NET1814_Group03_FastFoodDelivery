using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.OrderStatusVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories.Interfaces
{
    public interface IOrderStatusRepository : IGenericRepository<OrderStatusCreateVM>
	{
		Task<IEnumerable<Category>> GetOrderStatusByShipperId(string shipperId);
        Task<APIResponseModel> ChangeOrderStatus(string orderStatusId);
    }
}
