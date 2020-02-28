using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using ClassPlanner.Infra.Context;
using ClassPlanner.Infra.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ClassPlanner.Infra.Repositories.StudentsClassRepository
{
    public class StudentsClassRepository : GenericRepository<StudentsClass>,
        IStudentsClassRepository
    {
        public StudentsClassRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<StudentsClass> GetAllClassesWithEnrolledStudentsAndTeacher()
        {
            return _dbContext.Set<StudentsClass>()
                             .Include(x => x.EnrolledStudents)
                             .Include(x => x.TeacherInCharge)
                             .AsNoTracking();
        }

        public StudentsClass GetClassWithEnrolledStudentsAndTeacher(Guid studentCLassId)
        {
            return _dbContext.Set<StudentsClass>()
                             .Include(x => x.EnrolledStudents)
                             .Include(x => x.TeacherInCharge)
                             .FirstOrDefault(x => x.Id == studentCLassId);
        }
    }
}