using ClassPlanner.Domain.Entities;
using ClassPlanner.Infra.Context;
using ClassPlanner.Infra.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ClassPlanner.Infra.Repositories.StudentsClassRepository.TeacherInChargeRepository
{
    public class TeacherInChargeRepository : GenericRepository<TeacherInCharge>
    {
        public TeacherInChargeRepository(MainContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<TeacherInCharge> GetAllTeachersInChargeAndClasses()
        {
            return _dbContext.Set<TeacherInCharge>()
                             .Include(x => x.Teacher)
                             .Include(x => x.StudentsClass)
                             .Where(x => x.Active == true)
                             .AsNoTracking();
        }

        public TeacherInCharge GetTeacherInChargeByClassId(Guid studentCLassId)
        {
            return _dbContext.Set<TeacherInCharge>()
                             .Include(x => x.StudentsClass)
                             .FirstOrDefault(x => x.StudentsClass.Id == studentCLassId 
                                             && x.Active == true);
        }
    }
}
