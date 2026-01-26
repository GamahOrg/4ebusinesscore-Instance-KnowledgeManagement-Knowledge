namespace Knowledge.Domain.Models
{
	public class SubKnowledgeOrg : BaseEntity<Guid>
	{
		public Guid OrgId { get; set; }
		public Guid SubKnowledgeId { get; set; }
		public SubKnowledge SubKnowledge { get; set; }
	}
}
