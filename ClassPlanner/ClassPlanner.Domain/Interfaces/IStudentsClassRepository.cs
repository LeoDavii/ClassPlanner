using ClassPlanner.Domain.Entities;
using System;
using System.Linq;

namespace ClassPlanner.Domain.Interfaces
{
    public interface IStudentsClassRepository : IGenericRepository<StudentsClass>
    {
        IQueryable<StudentsClass> GetAllClassesWithEnrolledStudentsAndTeacher();
        StudentsClass GetClassWithEnrolledStudentsAndTeacher(Guid studentCLassId);
    }
}
