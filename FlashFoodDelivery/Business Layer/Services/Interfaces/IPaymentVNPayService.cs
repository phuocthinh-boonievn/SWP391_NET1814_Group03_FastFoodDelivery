﻿using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IPaymentVNPayService
    {
        Task<string> CreatePaymentRequestAsync(Order order);
    }
}
