﻿using Data_Layer.ResourceModel.ViewModel;

namespace Business_Layer.Repositories.Interfaces
{
    public interface IMenuFoodItemRepository
    {
        Task<List<MenuFoodItemVM>> GetMenuFoodItem();
        Task<MenuFoodItemVM> GetMenuFoodItemById(Guid Id);
        Task<bool> AddProduct(MenuFoodItemVM menuFoodItemVM);
    }
}
