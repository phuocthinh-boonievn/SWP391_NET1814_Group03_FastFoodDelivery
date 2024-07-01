using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel;
using Data_Layer.ResourceModel.ViewModel.OrderStatusVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
	public interface IOrderStatusService
	{
		Task<APIResponseModel> GetOrderStatusByShipperId(string shipperId);
		Task<APIResponseModel> ChangeOrderStatus(Guid orderStatusId);
		Task<APIResponseModel> GetOrderStatusAsync();
		Task<APIResponseModel> GetOrderStatusByIdsAsync(Guid id);
		Task<APIResponseModel> CreateOrderStatusAsync(OrderStatusCreateVM OrderStatus);
		Task<APIResponseModel> UpdateOrderStatusAsync(Guid id, OrderStatusCreateVM OrderStatus);
		Task<APIResponseModel> DeleteOrderStatus(Guid id);
	}
}
