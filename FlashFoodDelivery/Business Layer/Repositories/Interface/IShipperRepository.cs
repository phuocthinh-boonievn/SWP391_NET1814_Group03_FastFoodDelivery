using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories.Interface
{
	public interface IShipperRepository
	{
		public List<Shipper> GetAllShipper();
		public Shipper GetShipperById(Guid id);
		public Shipper GetShipperByUserId(string userId);
		public void AddShipper(Shipper shipper);
		public void DeleteShipperById(Guid id);
		public void UpdateShipper(Shipper shipper);
	}
}
