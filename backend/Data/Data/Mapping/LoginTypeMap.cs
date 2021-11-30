using Business.Models;
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
            builder.HasKey(x => x.Id)
                .HasName("PK_Login_Type");

            #region properties

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            #endregion properties
        }
    }
}