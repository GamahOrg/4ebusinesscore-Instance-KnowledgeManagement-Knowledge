namespace Knowledge.Infrastructure.ModelsConfigurations
{
	public class SubKnowledgeConfig:IEntityTypeConfiguration<SubKnowledge>
	{
		public void Configure(EntityTypeBuilder<SubKnowledge> builder)
		{
			builder.HasMany(a => a.KnowledgeViews)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);

			builder.HasMany(a => a.KnowledgeLikes)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);

			builder.HasMany(a => a.KnowledgeAttachments)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);

			builder.HasMany(a => a.KnowledgeFavoirates)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);

			builder.HasMany(a => a.KnowledgeRates)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);

			builder.HasMany(a => a.WorkParticipants)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);

			builder.HasMany(a => a.ParticipatingParties)
					.WithOne(a => a.SubKnowledge)
					.HasForeignKey(a => a.SubKnowledgeId);
		}
	}
}
