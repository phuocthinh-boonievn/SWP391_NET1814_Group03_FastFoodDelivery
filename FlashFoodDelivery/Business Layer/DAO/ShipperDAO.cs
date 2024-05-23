using Business_Layer.DataAccess;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.DAO
{
	public class ShipperDAO
	{
		private FastFoodDeliveryDBContext _DBContext;
		private static ShipperDAO _instance;

		public ShipperDAO()
		{
			_DBContext = new FastFoodDeliveryDBContext();
		}
		public static ShipperDAO Instance
		{
			get
			{
				if(_instance  == null)
				{
					_instance = new ShipperDAO();
				}
				return _instance;
			}
		}
		public List<Shipper> GetAllShipper()
		{
			return _DBContext.Shippers.ToList();
		}
		public Shipper GetShipperById(Guid id)
		{
			return _DBContext.Shippers.FirstOrDefault(s => s.ShipperId.Equals(id));
		}
		public Shipper GetShipperByUserId(string userId)
		{
			return _DBContext.Shippers.FirstOrDefault(s => s.userId.Equals(userId));
		}
		public void AddShipper(Shipper shipper)
		{
			Shipper s = GetShipperByUserId(shipper.userId);
			if(s == null)
			{
				shipper.ShipperStatus = "Ready";
				_DBContext.Shippers.Add(shipper);
				_DBContext.SaveChanges();
			}
		}
		public void DeleteShipperById(Guid id)
		{
			Shipper shipper = GetShipperById(id);
			if(shipper != null)
			{
				_DBContext.Shippers.Remove(shipper);
				_DBContext.SaveChanges();
			}
		}
		public void UpdateShipper(Shipper shipper)
		{
			Shipper s = GetShipperById(shipper.ShipperId);
			if (s != null)
			{
				s.Orders = shipper.Orders;
				s.ShipperStatus = shipper.ShipperStatus;
				_DBContext.SaveChanges();
			}
		}
	}
}
