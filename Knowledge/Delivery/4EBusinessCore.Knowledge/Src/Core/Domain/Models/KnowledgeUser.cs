



namespace Knowledge.Domain.Models
{
    public class KnowledgeUser : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
