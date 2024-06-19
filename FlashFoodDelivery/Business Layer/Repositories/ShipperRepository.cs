using AutoMapper;
using Business_Layer.DataAccess;
using Business_Layer.Repositories.Interface;
using Data_Layer.Models;
using Data_Layer.ResourceModel.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories
{
	public class ShipperRepository : IShipperRepository
	{
		private readonly FastFoodDeliveryDBContext _context;
		private readonly IMapper _mapper;
		private UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public ShipperRepository(FastFoodDeliveryDBContext context, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<List<ShipperVM>> GetAllShipper()
		{
			var shippers = await _userManager.GetUsersInRoleAsync("Shipper");
			var result = _mapper.Map<List<ShipperVM>>(shippers);
			return result;
		}

		public async Task<ShipperVM> GetShipperByUserId(string userId)
		{
			var shipper = _userManager.FindByIdAsync(userId);
			var result = _mapper.Map<ShipperVM>(shipper);
			return result;
		}

	}
}
