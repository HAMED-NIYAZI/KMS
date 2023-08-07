using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMS.Data.EntitiesConfiguration
{
    public class HomePageSettingConfiguration : IEntityTypeConfiguration<HomePageSetting>
    {
        public void Configure(EntityTypeBuilder<HomePageSetting> builder)
        {


            //builder.Property(h => h.Description)
            //      .HasMaxLength(1000)
            //      .IsRequired(false);

            //builder.Property(h => h.ImagePath)
            // .HasMaxLength(100)
            // .IsRequired(false);

            //builder.Property(h => h.Title)
            //     .HasMaxLength(100)
            //     .IsRequired();


            ////builder.HasOne(h => h.Organization)
            ////       .WithOne(o => o.HomePageSetting)
            ////       .HasForeignKey<HomePageSetting>(h => h.OrganizationId)
            ////       .OnDelete(DeleteBehavior.Restrict);


            ////default value

            //builder.Property(o => o.CreateDate).HasDefaultValueSql("GetDate()");
            //builder.Property(o => o.LastUpdateDate).HasDefaultValueSql("GetDate()");
            //builder.Property(o => o.IsDeleted).HasDefaultValue(false);
            //builder.Property(h => h.Coulmn1).IsRequired(false);
            //builder.Property(h => h.Coulmn2).IsRequired(false);
            //builder.Property(h => h.Coulmn3).IsRequired(false);
            //builder.Property(h => h.Coulmn4).IsRequired(false);
            //builder.Property(h => h.Coulmn5).IsRequired(false);



        }
    }
}
