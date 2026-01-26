namespace Knowledge.Infrastructure.ModelsConfigurations
{
	public class KnowledgeCategoryConfig:IEntityTypeConfiguration<LKP_KnowledgeCategory>
	{
		public void Configure(EntityTypeBuilder<LKP_KnowledgeCategory> builder)
		{
			//builder.HasMany(a => a.SubKnowledges)
			//		.WithOne(a => a.Category)
			//		.HasForeignKey(a => a.CategoryId);

			//builder.HasMany(a => a.Knowledges)
			//		.WithOne(a => a.Category)
			//		.HasForeignKey(a => a.CategoryId);
		}
	}
}
