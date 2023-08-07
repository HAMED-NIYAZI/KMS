using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMS.Data.EntitiesConfiguration
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(c => c.Description).HasMaxLength(2000).IsRequired(false);

            ////default value
            //builder.Property(c => c.SortingNumber).HasDefaultValue(0);

            //builder.Property(o => o.CreateDate).HasDefaultValueSql("GetDate()");
            //builder.Property(o => o.LastUpdateDate).HasDefaultValueSql("GetDate()");
            //builder.Property(o => o.IsDeleted).HasDefaultValue(false);

            ////one to many
            //builder.HasMany(c => c.Knowledges)
            //       .WithOne(o => o.Form)
            //       .HasForeignKey(c => c.FormId)
            //       .IsRequired(false);



        }
    }
}
