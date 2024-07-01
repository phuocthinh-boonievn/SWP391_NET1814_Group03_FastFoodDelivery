using AutoMapper;
using Business_Layer.Repositories.Interfaces;
using Business_Layer.Services.Interfaces;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel;
using Data_Layer.ResourceModel.ViewModel.OrderStatusVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
	public class OrderStatusService :IOrderStatusService
	{
		private readonly IOrderStatusRepository _orderStatusRepository;
		private readonly IMapper _mapper;

		public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper)
		{
			_orderStatusRepository = orderStatusRepository;
			_mapper = mapper;
		}

		public Task<APIResponseModel> ChangeOrderStatus(Guid orderStatusId)
		{
			return _orderStatusRepository.ChangeOrderStatus(orderStatusId);
		}

		public async Task<APIResponseModel> CreateOrderStatusAsync(OrderStatusCreateVM orderStatus)
		{
			APIResponseModel responseModel = new APIResponseModel();
			try
			{
				var Entity = _mapper.Map<OrderStatus>(orderStatus);
				Entity.OrderStatusName = "Processing";
				await _orderStatusRepository.AddAsync(Entity);
				if (await _orderStatusRepository.SaveAsync() > 0)
				{
					responseModel.Data = _mapper.Map<OrderStatusCreateVM>(Entity);
					responseModel.code = 200;
					responseModel.IsSuccess = true;
					responseModel.message = "Create new Order Stastus Successfully";
				}
			}
			catch (Exception ex)
			{
				responseModel.code = 500;
				responseModel.IsSuccess = false;
				responseModel.message = ex.Message;
			}

			return responseModel;
		}

		public async Task<APIResponseModel> DeleteOrderStatus(Guid id)
		{
			var reponse = new APIResponseModel();
			try
			{
				var OrderStatusChecked = await _orderStatusRepository.GetByIdAsync(id);

				if (OrderStatusChecked == null)
				{
					reponse.IsSuccess = false;
					reponse.message = "Not found Category, you are sure Input";
				}
				else
				{
					var OrderStatusUpdateStatus = _mapper.Map<OrderStatusCreateVM>(OrderStatusChecked);
					var OrderStatusDTOAfterUpdate = _mapper.Map<OrderStatusCreateVM>(OrderStatusUpdateStatus);
					if (await _orderStatusRepository.SaveAsync() > 0)
					{

						reponse.Data = OrderStatusDTOAfterUpdate;
						reponse.code = 200;
						reponse.IsSuccess = true;
						reponse.message = "Delete Order Status Successfully";
					}
					else
					{
						reponse.Data = OrderStatusDTOAfterUpdate;
						reponse.IsSuccess = false;
						reponse.message = "Delete orderStatus fail!";
					}
				}
			}
			catch (Exception ex)
			{
				reponse.IsSuccess = false;
				reponse.message = $"Delete orderStatus Fail!, exception {ex.Message}";
			}
			return reponse;
		}

		public async Task<APIResponseModel> GetOrderStatusAsync()
		{
			var reponse = new APIResponseModel();
			List<OrderStatusCreateVM> OrderStatusDTO = new List<OrderStatusCreateVM>();
			try
			{
				var OrderStatuses = await _orderStatusRepository.GetallOrderStatus();

				foreach (var orderStatus in OrderStatuses)
				{
					OrderStatusDTO.Add(_mapper.Map<OrderStatusCreateVM>(orderStatus));
				}
				if (OrderStatusDTO.Count > 0)
				{
					reponse.Data = OrderStatusDTO;
					reponse.code = 200;
					reponse.IsSuccess = true;
					return reponse;
				}
				else
				{
					reponse.IsSuccess = false;
					return reponse;
				}
			}
			catch (Exception ex)
			{

				reponse.IsSuccess = false;
				reponse.message = ex.Message;
				return reponse;
			}
		}

		public async Task<APIResponseModel> GetOrderStatusByIdsAsync(Guid id)
		{
			var _response = new APIResponseModel();
			try
			{
				var c = await _orderStatusRepository.GetByIdAsync(id);
				if (c == null)
				{
					_response.IsSuccess = false;
					_response.message = "Don't Have Any Order Status";
				}
				else
				{
					_response.Data = _mapper.Map<OrderStatusCreateVM>(c);
					_response.code = 200;
					_response.IsSuccess = true;
					_response.message = "find Order Status Successfully";
				}
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.message = ex.Message;
			}
			return _response;
		}

		public async Task<APIResponseModel> GetOrderStatusByShipperId(string shipperId)
		{
			var _response = new APIResponseModel();
			try
			{
				var c = await _orderStatusRepository.GetOrderStatusByShipperId(shipperId);
				if (c == null)
				{
					_response.IsSuccess = false;
					_response.message = "Don't Have Any Order Status";
				}
				else
				{
					_response.Data = _mapper.Map<OrderStatusCreateVM>(c);
					_response.code = 200;
					_response.IsSuccess = true;
					_response.message = "find Order Status Successfully";
				}
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.message = ex.Message;
			}
			return _response;
		}

		public async Task<APIResponseModel> UpdateOrderStatusAsync(Guid id, OrderStatusCreateVM OrderStatus)
		{
			var reponse = new APIResponseModel();
			try
			{
				var orderStatusChecked = await _orderStatusRepository.GetByIdAsync(id);
				if (orderStatusChecked == null )
				{
					reponse.IsSuccess = false;
					reponse.message = "Not found food";
				}
				else
				{
					var OrderStatusofUpdate = _mapper.Map(OrderStatus, orderStatusChecked);
					var OrderStatusDTOAfterUpdate = _mapper.Map<OrderStatusCreateVM>(OrderStatusofUpdate);
					if (await _orderStatusRepository.SaveAsync() > 0)
					{
						reponse.Data = OrderStatusDTOAfterUpdate;
						reponse.code = 200;
						reponse.IsSuccess = true;
						reponse.message = "Update Order Status successfully";
					}
					else
					{
						reponse.Data = OrderStatusDTOAfterUpdate;
						reponse.IsSuccess = false;
						reponse.message = "Update Order Status fail!";
					}
				}
			}
			catch (Exception ex)
			{
				reponse.IsSuccess = false;
				reponse.message = $"Update order Status fail!, exception {ex.Message}";
			}
			return reponse;
		}
	}
}
