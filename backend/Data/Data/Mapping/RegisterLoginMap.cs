using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegisterLoginAPI.Business.Models;

namespace Infra.Data.Mapping
{
    public class RegisterLoginMap : IEntityTypeConfiguration<RegisterLoginModel>
    {
        public void Configure(EntityTypeBuilder<RegisterLoginModel> builder)
        {
            builder.ToTable("register_login");

            //primary key
            builder.HasKey(x => x.Id)
                .HasName("PK_Register_Login");

            #region properties

            builder.Property(r => r.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(r => r.LoginName)
                .HasColumnName("login_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Password)
                .HasColumnName("password")
                .IsRequired();

            builder.Property(r => r.Observation)
                .HasColumnName("observation")
                .IsRequired();

            #endregion properties

            #region relationship

            builder.HasOne(r => r.LoginType)
                .WithOne()
                .HasForeignKey("login_type")
                .HasConstraintName("FK_Login_Type");

            #endregion relationship
        }
    }
}