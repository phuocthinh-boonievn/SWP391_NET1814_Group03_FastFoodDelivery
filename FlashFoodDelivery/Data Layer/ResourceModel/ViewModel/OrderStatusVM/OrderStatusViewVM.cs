using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.ResourceModel.ViewModel.OrderStatusVM
{
	public class OrderStatusViewVM
	{
		Guid orderId {  get; set; }
		string OrderStatusName { get; set; }
	}
}
