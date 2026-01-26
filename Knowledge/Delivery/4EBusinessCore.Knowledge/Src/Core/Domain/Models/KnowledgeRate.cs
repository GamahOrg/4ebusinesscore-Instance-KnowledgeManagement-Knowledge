namespace Knowledge.Domain.Models
{
    public class KnowledgeRate : BaseEntity<Guid>
    {
        public int RateValue { get; set; }
        public Guid SubKnowledgeId { get; set; }
        public SubKnowledge SubKnowledge { get; set; }
    }
}
