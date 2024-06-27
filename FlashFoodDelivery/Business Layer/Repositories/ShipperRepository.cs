using AutoMapper;
using Business_Layer.DataAccess;
using Business_Layer.Repositories.Interfaces;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.Enum;
using Data_Layer.ResourceModel.ViewModel.Shipper;
using Data_Layer.ResourceModel.ViewModel.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories
{
    public class ShipperRepository : GenericRepository<User>, IShipperRepository
	{
		private readonly FastFoodDeliveryDBContext _context;
		private readonly IMapper _mapper;
		private UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public ShipperRepository(FastFoodDeliveryDBContext context, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : base(context)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<List<ShipperVM>> GetAllShipper()
		{
			var shippers = await _userManager.GetUsersInRoleAsync("Shipper");
			var shipperList = new List<ShipperVM>();
			foreach (var shipper in shippers)
			{
				var shipperVM = new ShipperVM();
				var orders = _context.Orders.Where(x => x.ShipperId.Equals(shipper.Id)).ToList();
				shipperVM.shipperId = shipper.Id;
				shipperVM.name = shipper.FullName;
				if (orders != null)
				{
					foreach(var order in orders)
					{
						shipperVM.orderStatusId.Add(order.OrderId);
					}
				}
				else shipperVM.orderStatusId = null;
				shipperList.Add(shipperVM);
			}
			var result = _mapper.Map<List<ShipperVM>>(shipperList);
			return result;
		}

		public async Task<IEnumerable<ShipperVM>> GetShippeAccountAll()
		{
			var shippers = await _userManager.GetUsersInRoleAsync("Shipper");
			var shipperList = new List<ShipperVM>();
			foreach (var shipper in shippers)
			{
				var shipperVM = new ShipperVM();
				var orders = _context.Orders.Where(x => x.ShipperId.Equals(shipper.Id)).ToList();
				shipperVM.shipperId = shipper.Id;
				shipperVM.name = shipper.FullName;
				if (orders != null)
				{
					foreach (var order in orders)
					{
						shipperVM.orderStatusId.Add(order.OrderId);
					}
				}
				else shipperVM.orderStatusId = null;
				shipperList.Add(shipperVM);
			}
			var result = _mapper.Map<List<ShipperVM>>(shipperList);
			return result;
		}

		public async Task<APIResponseModel> CreateShipperAccount(ShipperCreateVM model)
		{
			APIResponseModel result = new APIResponseModel()
			{
				code = 200,
				IsSuccess = true,
				message = "Shipper created success",


			};

			var userExistName = await _userManager.FindByNameAsync(model.Username);
			if (userExistName != null)
			{
				return new APIResponseModel
				{
					code = 400,
					message = "User has been already existed!",
					IsSuccess = false,
				};
			}


			var user = new User()
			{
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Username,
				FullName = model.FullName,
				Status = UserEnum.Active.ToString(),

			};
			var resultCreateUser = await _userManager.CreateAsync(user, model.Password);
			var resultRole = await _userManager.AddToRoleAsync(user, "Shipper");

			if (!resultCreateUser.Succeeded)
			{
				return new APIResponseModel()
				{
					code = 200,
					message = "Error when create user",
					IsSuccess = false,

				};
			}
			return new APIResponseModel()
			{
				code = 200,
				message = "Add shipper successfully",
				IsSuccess = true,
				Data = user,
			};
		}
	}
}
