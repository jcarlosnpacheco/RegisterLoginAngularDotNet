using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegisterLoginAPI.Business.Entity;

namespace Infra.Data.Mapping
{
    public class RegisterLoginMap : IEntityTypeConfiguration<RegisterLogin>
    {
        public void Configure(EntityTypeBuilder<RegisterLogin> builder)
        {
            builder.ToTable("register_login");

            //primary key
            builder.HasKey(x => x.Id)
                .HasName("PK_Register_Login");

            #region properties

            builder.Property(r => r.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(r => r.LoginName)
                .HasColumnName("login_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Password)
                .HasColumnName("password")
                .IsRequired();

            builder.Property(r => r.Observation)
                .HasColumnName("observation");

            builder.Property(r => r.LoginTypeId)
               .HasColumnName("login_type_id")
               .IsRequired();

            #endregion properties
        }
    }
}