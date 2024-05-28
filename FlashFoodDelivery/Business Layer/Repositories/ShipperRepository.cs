using AutoMapper;
using Business_Layer.DataAccess;
using Business_Layer.Repositories.Interface;
using Data_Layer.Models;
using Data_Layer.ResourceModel.ViewModel;
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

		public async Task<bool> AddShipper(ShipperVM shipperVM)
		{
			var shipper = _mapper.Map<Shipper>(shipperVM);
			_context.Shippers.Add(shipper);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteShipperById(Guid id)
		{
			var shipper = _mapper.Map<Shipper>(GetShipperById(id));
			_context.Shippers.Remove(shipper);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<List<ShipperVM>> GetAllShipper()
		{
			var shippers = _context.Shippers.ToListAsync();
			var result = _mapper.Map<List<ShipperVM>>(shippers);
			return result;
		}

		public async Task<ShipperVM> GetShipperById(Guid id)
		{
			var shipper = _context.Shippers.FirstOrDefaultAsync(s => s.ShipperId.Equals(id));
			var result = _mapper.Map<ShipperVM>(shipper);
			return result;
		}

		public async Task<ShipperVM> GetShipperByUserId(string userId)
		{
			var shipper = _context.Shippers.FirstOrDefaultAsync(s => s.ShipperId.Equals(userId));
			var result = _mapper.Map<ShipperVM>(shipper);
			return result;
		}

		public async Task<bool> UpdateShipper(ShipperVM shipperVM)
		{
			var shipper = _mapper.Map<Shipper>(shipperVM);
			_context.Shippers.Update(shipper);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
