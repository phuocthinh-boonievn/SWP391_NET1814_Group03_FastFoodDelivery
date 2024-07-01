using AutoMapper;
using Business_Layer.Commons;
using Business_Layer.Repositories.Interfaces;
using Business_Layer.Services.Interfaces;
using Data_Layer.Models;
using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.Enum;
using Data_Layer.ResourceModel.ViewModel.Shipper;
using Data_Layer.ResourceModel.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class ShipperService : IShipperService
    {
		private readonly IShipperRepository _shipperRepository;
		private readonly IClaimsService _claimsService;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;

		public ShipperService(IShipperRepository shipperRepository, IClaimsService claimsService, IMapper mapper, UserManager<User> userManager)
		{
			_shipperRepository = shipperRepository;
			_claimsService = claimsService;
			_mapper = mapper;
			_userManager = userManager;
		}
		public async Task<ShipperVM> GetShipperById(string id)
		{
			var user = await _shipperRepository.GetShippeAccountById(id);
			if (user != null)
			{
				return new ShipperVM
				{
					name = user.name,
					orderStatusId = user.orderStatusId,
					shipperId = user.shipperId,
				};
			}
			return null;
		}

		
		public async Task<APIResponseModel> GetShipperAsync()
		{
			var reponse = new APIResponseModel();
			try
			{
				var users = await _shipperRepository.GetShippeAccountAll();

				if (users.Count() > 0)
				{
					reponse.code = 200;
					reponse.Data = users;
					reponse.IsSuccess = true;
					reponse.message = $"Have {users.Count()} Accounts";
					return reponse;
				}
				else
				{
					reponse.IsSuccess = false;
					reponse.message = $"Have {users.Count()} Accounts";
					return reponse;
				}
			}
			catch (Exception e)
			{
				reponse.IsSuccess = false;
				reponse.message = e.Message;
				return reponse;
			}
		}

		public Task<APIResponseModel> CreateShipperAccount(ShipperCreateVM model)
		{
			return _shipperRepository.CreateShipperAccount(model);
		}
	}
}
