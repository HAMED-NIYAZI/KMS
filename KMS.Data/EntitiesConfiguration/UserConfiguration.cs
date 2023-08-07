using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMS.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //builder.HasKey(x => x.Id);


            //builder.Property(u => u.CodeMeli)
            //       .HasMaxLength(10);


            ////one to many   one=chart   many=users 
            //builder.HasOne(u => u.Chart)
            //       .WithMany(c=>c.Users)
            //       .HasForeignKey(u=>u.ChartId);

            //builder.HasMany(u => u.Knowledges)
            //       .WithOne(k => k.User)
            //       .HasForeignKey(u => u.OwnerUserId);

            //builder.Property(u => u.CreateDate)
            //    .HasDefaultValueSql("GetDate()");

        }
    }
}
