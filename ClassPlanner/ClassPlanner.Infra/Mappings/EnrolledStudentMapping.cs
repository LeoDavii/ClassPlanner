using ClassPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassPlanner.Infra.Mappings
{
    public class EnrolledStudentMapping : IEntityTypeConfiguration<EnrolledStudent>
    {
        public void Configure(EntityTypeBuilder<EnrolledStudent> builder)
        {
            builder.Property(x => x.Active).HasColumnName(nameof(EnrolledStudent.Active)).IsRequired();
            builder.Property(x => x.Value).HasColumnName(nameof(EnrolledStudent.Value)).IsRequired();
            builder.Property(x => x.StudentId).HasColumnName(nameof(EnrolledStudent.StudentId)).IsRequired();
            builder.HasOne(x => x.StudentsClass).WithMany().HasForeignKey(d => d.StudentsClassId).IsRequired();
            builder.Property(d => d.CreationDate).HasColumnName(nameof(EnrolledStudent.CreationDate)).IsRequired();
            builder.Property(d => d.AlterationDate).HasColumnName(nameof(EnrolledStudent.AlterationDate)).IsRequired();
        }
    }
}
