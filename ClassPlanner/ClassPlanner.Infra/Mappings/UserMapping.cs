using ClassPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassPlanner.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(d => d.Name).HasColumnName(nameof(User.Name)).IsRequired();
            builder.Property(d => d.EmailLogin).HasColumnName(nameof(User.EmailLogin)).IsRequired();
            builder.Property(d => d.Password).HasColumnName(nameof(User.Password)).IsRequired();
            builder.Property(d => d.Role).HasColumnName(nameof(User.Role)).IsRequired();
            builder.Property(d => d.CreationDate).HasColumnName(nameof(User.CreationDate)).IsRequired();
            builder.Property(d => d.AlterationDate).HasColumnName(nameof(User.AlterationDate)).IsRequired();
            builder.Property(d => d.Active).HasColumnName(nameof(User.AlterationDate));
        }
    }
}
