using System.ComponentModel.DataAnnotations.Schema;

namespace Knowledge.Domain.Models
{
    public class SubKnowledge : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Targets { get; set; }
        public string? Legislation { get; set; }
        public DateTime? Date { get; set; }
        //public Guid CategoryId { set; get; }
        //public LKP_KnowledgeCategory Category { get; set; }
        public Guid KnowledgeId { get; set; }
        public virtual Knowledge Knowledge { get; set; }
		public virtual ICollection<SubKnowledgeOrg> ParticipatingParties { get; set; }
		public virtual ICollection<SubKnowledgeUser>? WorkParticipants { get; set; }
		public virtual ICollection<KnowledgeAttachments> KnowledgeAttachments { get; set; }
        public virtual ICollection<KnowledgeRate> KnowledgeRates { get; set; }
        public virtual ICollection<KnowledgeViews> KnowledgeViews { get; set; }
        public virtual ICollection<KnowledgeFavoirate> KnowledgeFavoirates { get; set; }
        public virtual ICollection<KnowledgeLike> KnowledgeLikes { get; set; }
    }
}
