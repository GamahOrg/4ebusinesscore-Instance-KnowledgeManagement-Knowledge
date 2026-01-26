

namespace Knowledge.Domain.Models
{
    public class KnowledgeOrg : BaseEntity<Guid>
    {
        public Guid OrgId { get; set; }
        public Guid KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
