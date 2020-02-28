using ClassPlanner.Domain.Entities;
using System;
using System.Linq;

namespace ClassPlanner.Domain.Interfaces
{
    public interface ITeacherInChargeRepository : IGenericRepository<TeacherInCharge>
    {
        IQueryable<TeacherInCharge> GetAllTeachersInChargeAndClasses();
        TeacherInCharge GetTeacherInChargeByClassId(Guid studentCLassId);
    }
}