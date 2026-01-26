//namespace Knowledge.Infrastructure.ModelsConfigurations
//{
//    public class SubKnowledgeCategoryConfig : IEntityTypeConfiguration<LK_SubKnowledgeCategory>
//    {
//        public void Configure(EntityTypeBuilder<LK_SubKnowledgeCategory> builder)
//        {
//            builder.HasMany(a => a.SubKnowledges)
//                    .WithOne(a => a.SubKnowledgeCategory)
//                    .HasForeignKey(a => a.SubKnowledgeCategoryId);

//        }
//    }
//}
