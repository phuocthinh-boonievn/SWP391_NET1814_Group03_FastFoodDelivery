﻿using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<IEnumerable<Order>> GetAllOrderByUserIdAsync(string userID);
        public Task<IEnumerable<Order>> GetAllByStatusAsync(string status);
        Task<IEnumerable<Order>> GetConfirmedOrders();
    }
}
