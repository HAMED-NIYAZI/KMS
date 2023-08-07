using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMS.Data.EntitiesConfiguration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
           // builder.HasKey(o => o.Id);
           // builder.Property(o => o.PersianTitle).HasMaxLength(100).IsRequired();
           // builder.Property(o => o.EnglishTitle).HasMaxLength(100).IsRequired(false);
           // builder.Property(o => o.Description).HasMaxLength(2000).IsRequired(false);


           ////default value
           //builder.Property(o => o.SortingNumber).HasDefaultValue(0);

           //builder.Property(o => o.CreateDate).HasDefaultValueSql("GetDate()");
           //builder.Property(o => o.LastUpdateDate).HasDefaultValueSql("GetDate()");
           //builder.Property(o => o.IsDeleted).HasDefaultValue(false);
 




            //builder.HasOne(o => o.Parent)
            //       .WithMany(o => o.Children)
            //       .HasForeignKey(o=>o.ParentId)
            //       .IsRequired(false);





        }
    }
}
