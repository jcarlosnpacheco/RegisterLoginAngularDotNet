using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.Mapping
{
    public class LoginTypeMap : IEntityTypeConfiguration<LoginTypeModel>
    {
        public void Configure(EntityTypeBuilder<LoginTypeModel> builder)
        {
            //table name
            builder.ToTable("login_type");

            //primary key
            builder.HasKey(x => x.Id)
                .HasName("PK_Login_Type");

            #region properties

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            #endregion properties
        }
    }
}