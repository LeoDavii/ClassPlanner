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
            builder.Property(d => d.CPF).HasColumnName(nameof(Student.CPF)).IsRequired();
            builder.Property(d => d.Address).HasColumnName(nameof(Student.Address)).IsRequired();
            builder.Property(d => d.Contact).HasColumnName(nameof(Student.Contact)).IsRequired();
            builder.Property(d => d.PrivateStudent).HasColumnName(nameof(Student.PrivateStudent)).IsRequired();
            builder.Property(d => d.Active).HasColumnName(nameof(Student.Active)).IsRequired();
            builder.Property(d => d.CreationDate).HasColumnName(nameof(Student.CreationDate)).IsRequired();
            builder.Property(d => d.AlterationDate).HasColumnName(nameof(Student.AlterationDate)).IsRequired();
        }
    }
}
