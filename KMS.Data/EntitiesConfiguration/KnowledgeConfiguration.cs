using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMS.Data.EntitiesConfiguration
{
    public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {

            //builder.HasKey(k => k.Id);


            //builder.HasAlternateKey(k => k.Code);

            //builder.Property(k => k.Title).HasMaxLength(200).IsRequired();
            //builder.Property(k => k.Description).HasMaxLength(5000).IsRequired();
            //builder.Property(k=>k.FinalScore).IsRequired(false);



            ////one to many   one=Form   many=Knowledges 
            //builder.HasOne(u => u.Form)
            //       .WithMany(k=>k.Knowledges)
            //       .HasForeignKey(u=>u.FormId)
            //       .IsRequired();

            ////one to many   one=Form   many=Knowledges 
            //builder.HasOne(u => u.User)
            //       .WithMany(k => k.Knowledges)
            //       .HasForeignKey(u => u.OwnerUserId)
            //       .IsRequired();



            //builder.Property(u => u.CreateDate)
            //    .HasDefaultValueSql("GetDate()");

        }
    }
}
