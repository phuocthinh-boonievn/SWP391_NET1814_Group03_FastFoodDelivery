using Business_Layer.Repositories.Interface;
using Data_Layer.DAO;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories
{
	public class ShipperRepository : IShipperRepository
	{
		public void AddShipper(Shipper shipper) => ShipperDAO.Instance.AddShipper(shipper);

		public void DeleteShipperById(Guid id) => ShipperDAO.Instance.DeleteShipperById(id);

		public List<Shipper> GetAllShipper() => ShipperDAO.Instance.GetAllShipper();

		public Shipper GetShipperById(Guid id) => ShipperDAO.Instance.GetShipperById(id);

		public Shipper GetShipperByUserId(string userId) => ShipperDAO.Instance.GetShipperByUserId(userId);

		public void UpdateShipper(Shipper shipper) => ShipperDAO.Instance.UpdateShipper(shipper);
	}
}
