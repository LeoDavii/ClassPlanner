using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using ClassPlanner.Infra.Context;
using ClassPlanner.Infra.Repositories.GenericRepository;

namespace ClassPlanner.Infra.Repositories.TeacherRepository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
