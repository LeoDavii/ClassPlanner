using ClassPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassPlanner.Infra.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(d => d.Name).HasColumnName(nameof(Student.Name)).IsRequired();
            builder.Property(d => d.Id).HasColumnName(nameof(Student.Id)).IsRequired();
            builder.Property(d => d.Active).HasColumnName(nameof(Student.Active)).IsRequired();
        }
    }
}
