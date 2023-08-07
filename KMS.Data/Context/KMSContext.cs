using KMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class KMSContext : DbContext
    {
        public KMSContext(DbContextOptions<KMSContext> options)
            : base(options)
        {

        }

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<HomePageSetting> HomePageSettings { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
       // public DbSet<KnowledgeField> KnowledgeFields { get; set; }





        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetail> ComboDetails { get; set; }
        public DbSet<DateText> DateTexts { get; set; }
        public DbSet<LongText> LongTexts { get; set; }
        public DbSet<RadioButtonYesNo> RadioButtonYesNos { get; set; }
        public DbSet<ShortTest> ShortTests { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Add Entities Configurations by typeof(KMSContext).Assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KMSContext).Assembly);
            #endregion


            base.OnModelCreating(modelBuilder);
        }


    }
}
