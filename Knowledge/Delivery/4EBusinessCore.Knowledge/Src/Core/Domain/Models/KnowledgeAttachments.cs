namespace Knowledge.Domain.Models
{
    public class KnowledgeAttachments : BaseEntity<Guid>
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Guid SubKnowledgeId { get; set; }
        public virtual SubKnowledge SubKnowledge { get; set; }
    }
}
