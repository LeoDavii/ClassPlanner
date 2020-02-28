using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using ClassPlanner.Infra.Context;
using ClassPlanner.Infra.Repositories.GenericRepository;

namespace ClassPlanner.Infra.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
