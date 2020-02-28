using ClassPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ClassPlanner.Infra.Mappings
{
    public class StudentsClassMapping : IEntityTypeConfiguration<StudentsClass>
    {
        public void Configure(EntityTypeBuilder<StudentsClass> builder)
        {
            builder.Property(x => x.Name).HasColumnName(nameof(StudentsClass.Name)).IsRequired();
            builder.Property(x => x.Active).HasColumnName(nameof(StudentsClass.Active)).IsRequired();
            builder.HasMany(x => x.EnrolledStudents).WithOne(d => d.StudentsClass);
            builder.HasOne(x => x.TeacherInCharge).WithOne(d => d.StudentsClass);
            builder.Property(d => d.CreationDate).HasColumnName(nameof(StudentsClass.CreationDate)).IsRequired();
            builder.Property(d => d.AlterationDate).HasColumnName(nameof(StudentsClass.AlterationDate)).IsRequired();
        }
    }
}
