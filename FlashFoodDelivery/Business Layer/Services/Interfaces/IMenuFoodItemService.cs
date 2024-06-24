﻿using Data_Layer.ResourceModel.Common;
using Data_Layer.ResourceModel.ViewModel.MenuFoodItemVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IMenuFoodItemService
    {
		Task<APIResponseModel> GetFoodsAsync();
		Task<APIResponseModel> GetFoodByIdsAsync(Guid foodId);
		Task<APIResponseModel> GetFoodsByCategoryIdAsync(Guid categoryId);
		Task<APIResponseModel> CreateFoodAsync(MenuFoodItemCreateVM createdto);
		Task<APIResponseModel> UpdateFoodAsync(Guid id, MenuFoodItemUpdateVM updatedto);
		Task<APIResponseModel> DeleteFood(Guid id);
	}
}
