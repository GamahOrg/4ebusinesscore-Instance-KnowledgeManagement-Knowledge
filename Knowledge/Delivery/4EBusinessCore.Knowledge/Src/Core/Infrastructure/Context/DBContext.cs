namespace Knowledge.Infrastructure.Context
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Domain.Models.Knowledge> Knowledges { get; set; }
		public DbSet<SubKnowledge> SubKnowledges { get; set; }
		public DbSet<KnowledgeAttachments> KnowledgeAttachments { get; set; }
		public DbSet<KnowledgeFavoirate> KnowledgeFavoirates { get; set; }
		public DbSet<KnowledgeLike> KnowledgeLikes { get; set; }
		public DbSet<KnowledgeRate> KnowledgeRates { get; set; }
		public DbSet<LKP_KnowledgeCategory> KnowledgeCategories { get; set; }
		public DbSet<KnowledgeViews> KnowledgeViews { get; set; }
        public DbSet<KnowledgeOrg> KnowalgeOrgs { get; set; }
        public DbSet<KnowledgeUser> KnowalgeUsers { get; set; }
        public DbSet<SubKnowledgeOrg> SubKnowalgeOrgs { get; set; }
		public DbSet<SubKnowledgeUser> SubKnowlageUsers { get; set; }

        public DbSet<LK_SubKnowledgeCategory> SubKnowledgeCategories { get; set; }

        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}