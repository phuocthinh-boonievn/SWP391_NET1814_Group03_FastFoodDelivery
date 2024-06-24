using Business_Layer.DataAccess;
using Business_Layer.Repositories.Interfaces;
using Data_Layer.Models;
namespace Business_Layer.Repositories
{
    public class FeedBackRepository : GenericRepository<FeedBack>, IFeedBackRepository
    {
        private readonly FastFoodDeliveryDBContext _dbContext;
        public FeedBackRepository(FastFoodDeliveryDBContext context, FastFoodDeliveryDBContext dbContext) : base(context)
        {
            _dbContext = dbContext;
        }
    }
}
