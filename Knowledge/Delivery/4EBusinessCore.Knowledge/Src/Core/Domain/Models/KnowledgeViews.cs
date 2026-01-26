namespace Knowledge.Domain.Models
{
    public class KnowledgeViews : BaseEntity<Guid>
    {
        public Guid SubKnowledgeId { get; set; }
        public SubKnowledge SubKnowledge { get; set; }
    }
}
