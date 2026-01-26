namespace Knowledge.Infrastructure.ModelsConfigurations
{
	public class KnowledgeConfig:IEntityTypeConfiguration<KnowledgeModel>
	{
		public void Configure(EntityTypeBuilder<KnowledgeModel> builder)
		{
			builder.HasMany(a => a.SubKnowledges)
					.WithOne(a => a.Knowledge)
					.HasForeignKey(a => a.KnowledgeId);
		}
	}
}
