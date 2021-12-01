using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegisterLoginAPI.Business.Entity;

namespace Infra.Data.Mapping
{
    public class LoginTypeMap : IEntityTypeConfiguration<LoginType>
    {
        public void Configure(EntityTypeBuilder<LoginType> builder)
        {
            //table name
            builder.ToTable("login_type");

            //primary key
            builder.HasKey(l => l.Id)
                .HasName("PK_Login_Type");

            #region properties

            builder.Property(l => l.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(l => l.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            #endregion properties
        }
    }
}