using AutoMapper;
using Business_Layer.DataAccess;
using Business_Layer.Repositories.Interfaces;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.OrderStatusVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
	{
		private readonly FastFoodDeliveryDBContext _context;
		private readonly IMapper _mapper;
		private UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public OrderStatusRepository(FastFoodDeliveryDBContext context, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : base(context)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		//public async Task<APIResponseModel> CreateOrderStatus(OrderStatusCreateVM orderStatus)
		//{
		//	try
		//	{_context.OrderStatuses.Add(orderStatus);
		//	_context.SaveChanges();
		//	return new APIResponseModel()
		//	{
		//		code = 200,
		//		message = "Create success",
		//		IsSuccess = true,
		//		Data = orderStatus
		//	}; 
		//	}catch (Exception ex)
		//	{
		//		return new APIResponseModel()
		//		{
		//			code = 200,
		//			message = "Create fail",
		//			IsSuccess = false,
		//		};
		//	}
		//}

		public async Task<IEnumerable<OrderStatusCreateVM>> GetOrderStatusByShipperId(string userId)
		{
			var shippers = await _userManager.GetUsersInRoleAsync("Shipper");
			var user = await _userManager.FindByIdAsync(userId);
			if (!shippers.Contains(user))
			{
				return null;
			}
			var orderStatuses = _context.OrderStatuses.Where(o => o.ShipperId.Equals(userId)).ToList();
			
			var result = _mapper.Map<List<OrderStatusCreateVM>>(orderStatuses);
			return result;
		}

		public async Task<APIResponseModel> ChangeOrderStatus(Guid orderStatusId)
		{
			var orderStatus = _context.OrderStatuses.FirstOrDefault(x => x.OrderStatusId.Equals(orderStatusId));
			try
			{
				switch (orderStatus.OrderStatusName)
				{
					case "Processing":
						orderStatus.OrderStatusName = "Delivering";
						break;

					case "Delivering":
						orderStatus.OrderStatusName = "Complete";
						break;
				}
				return new APIResponseModel()
				{
					code = 200,
					message = "Success",
					IsSuccess = true,
					Data = orderStatus,
				};
			}
			catch (Exception ex)
			{
				return new APIResponseModel()
				{
					code = 200,
					message = ex.Message,
					IsSuccess = false,
				};
			}
		}

		public async Task<IEnumerable<OrderStatusCreateVM>> GetallOrderStatus()
		{
			var list = _context.OrderStatuses.ToList();
			var result = _mapper.Map<IEnumerable<OrderStatusCreateVM>>(list);
			return result;
		}
	}
}
