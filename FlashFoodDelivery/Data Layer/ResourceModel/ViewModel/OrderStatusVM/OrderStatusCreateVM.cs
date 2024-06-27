using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.ResourceModel.ViewModel.OrderStatusVM
{
	public class OrderStatusCreateVM
	{
		string ShipperId { get; set; }
		Guid OrderId { get; set; }
		string OrderStatusName = "Processing";
	}
}
