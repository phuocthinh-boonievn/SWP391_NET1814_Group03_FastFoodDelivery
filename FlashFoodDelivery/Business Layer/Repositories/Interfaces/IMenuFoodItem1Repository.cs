using Data_Layer.Models;
namespace Business_Layer.Repositories.Interfaces
{
    public interface IMenuFoodItem1Repository : IGenericRepository<MenuFoodItem>
    {
        Task<IEnumerable<MenuFoodItem>> GetMenuFoodItemAll();
    }
}
