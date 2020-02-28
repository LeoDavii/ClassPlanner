using ClassPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassPlanner.Infra.Mappings
{
    public class TeacherInChargeMapping : IEntityTypeConfiguration<TeacherInCharge>
    {
        public void Configure(EntityTypeBuilder<TeacherInCharge> builder)
        {
            builder.Property(x => x.Active).HasColumnName(nameof(TeacherInCharge.Active)).IsRequired();
            builder.Property(x => x.TeacherId).HasColumnName(nameof(TeacherInCharge.TeacherId)).IsRequired();
            builder.HasOne(x => x.StudentsClass).WithMany().HasForeignKey(d => d.StudentsClassId).IsRequired();
            builder.Property(d => d.CreationDate).HasColumnName(nameof(TeacherInCharge.CreationDate)).IsRequired();
            builder.Property(d => d.AlterationDate).HasColumnName(nameof(TeacherInCharge.AlterationDate)).IsRequired();
        }
    }
}
