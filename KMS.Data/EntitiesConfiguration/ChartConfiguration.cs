using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMS.Data.EntitiesConfiguration
{
    public class ChartConfiguration : IEntityTypeConfiguration<Chart>
    {
        public void Configure(EntityTypeBuilder<Chart> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(c => c.PersianTitle).HasMaxLength(100).IsRequired();
            //builder.Property(c => c.EnglishTitle).HasMaxLength(100).IsRequired(false);
            //builder.Property(c => c.Description).HasMaxLength(2000).IsRequired(false);

            ////default value
            //builder.Property(c => c.SortingNumber).HasDefaultValue(0);

            //builder.Property(o => o.CreateDate).HasDefaultValueSql("GetDate()");
            //builder.Property(o => o.LastUpdateDate).HasDefaultValueSql("GetDate()");
            //builder.Property(o => o.IsDeleted).HasDefaultValue(false);

            ////one to many
            //builder.HasOne(c => c.Organization)
            //       .WithMany(o => o.Charts)
            //       .HasForeignKey(c => c.OrganizationId)
            //       .IsRequired();

            ////self relation
            //builder.HasOne(o => o.Parent)
            //       .WithMany(o => o.Children)
            //       .HasForeignKey(o => o.ParentId)
            //       .IsRequired(false);

        }
    }
}
