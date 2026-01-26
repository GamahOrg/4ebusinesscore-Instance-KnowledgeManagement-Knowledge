namespace Knowledge.Domain.Models
{
    public class KnowledgeLike:BaseEntity<Guid>
    {
        public Guid SubKnowledgeId { get; set; }
        public SubKnowledge SubKnowledge { get; set; }
        public LikeStatus LikeStatus { set; get; }
    }
}
