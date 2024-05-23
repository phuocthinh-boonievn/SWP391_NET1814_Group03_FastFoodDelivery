using AutoMapper;
using Business_Layer.DataAccess;
using Business_Layer.Repositories;
using Data_Layer.ResourceModel.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemFoodController : ControllerBase
    {
        public IMenuFoodItemRepository _menuFoodItemRepository;

        public MenuItemFoodController(IMenuFoodItemRepository menuFoodItemRepository)
        {
            _menuFoodItemRepository = menuFoodItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuFoodItem()
        {
            try
            {
                var result = await _menuFoodItemRepository.GetMenuFoodItem();
                return Ok(result);
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
