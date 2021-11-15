using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceOrderAPI.Business.Models;

namespace Data.Data.Mapping
{
    public class ServiceOrderMap : IEntityTypeConfiguration<ServiceOrderModel>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderModel> builder)
        {
            //table name
            builder.ToTable("service");

            //primary key
            builder.HasKey(x => x.Id);

            #region properties
            builder.Property(s => s.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(s => s.Date)
                .HasColumnName("date_service")
                .IsRequired();
            
            builder.Property(s => s.Value)
                .HasColumnName("value_service")
                .IsRequired();

            #endregion properties

            #region relationship
            #endregion relationship
        }
    }
}