using Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //table name
            builder.ToTable("user");

            //primary key
            builder.HasKey(u => u.Id)
                .HasName("PK_user");

            #region properties

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Username)
                .HasColumnName("username")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired();

            builder.Property(u => u.Role)
               .HasColumnName("role")
               .IsRequired();

            #endregion properties
        }
    }
}