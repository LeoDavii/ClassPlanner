using ClassPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassPlanner.Infra.Mappings
{
    public class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Active).HasColumnName(nameof(Teacher.Active)).IsRequired();
            builder.Property(x => x.Name).HasColumnName(nameof(Teacher.Name)).IsRequired();
            builder.Property(x => x.CPF).HasColumnName(nameof(Teacher.CPF)).IsRequired();
            builder.Property(d => d.CreationDate).HasColumnName(nameof(Teacher.CreationDate)).IsRequired();
            builder.Property(d => d.AlterationDate).HasColumnName(nameof(Teacher.AlterationDate)).IsRequired();
        }
    }
}
