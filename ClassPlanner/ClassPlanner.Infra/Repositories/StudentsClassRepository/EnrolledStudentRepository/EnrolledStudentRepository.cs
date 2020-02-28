using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using ClassPlanner.Infra.Context;
using ClassPlanner.Infra.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ClassPlanner.Infra.Repositories.StudentsClassRepository.EnrolledStudentRepository
{
    public class EnrolledStudentRepository : GenericRepository<EnrolledStudent>, 
        IEnrolledStudentRepository
    {
        public EnrolledStudentRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<EnrolledStudent> GetStudentsClassesByStudentId(Guid studentId)
        {
            return _dbContext.Set<EnrolledStudent>()
                              .Include(x => x.StudentsClass)
                              .Where(x => x.StudentId == studentId)
                              .AsNoTracking();
        }

        public EnrolledStudent GetStudentAndClassByRegistration(int registrationId)
        {
            return _dbContext.Set<EnrolledStudent>()
                              .Include(x => x.StudentsClass)
                              .Include(x => x.Student)
                              .FirstOrDefault(x => x.RegistrationId == registrationId);
        }
    }
}
