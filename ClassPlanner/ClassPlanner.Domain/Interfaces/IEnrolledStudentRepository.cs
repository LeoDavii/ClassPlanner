using ClassPlanner.Domain.Entities;
using System;
using System.Linq;

namespace ClassPlanner.Domain.Interfaces
{
    public interface IEnrolledStudentRepository : IGenericRepository<EnrolledStudent>
    {
        IQueryable<EnrolledStudent> GetStudentsClassesByStudentId(Guid studentId);
        EnrolledStudent GetStudentAndClassByRegistration(int registrationId);
    }
}
