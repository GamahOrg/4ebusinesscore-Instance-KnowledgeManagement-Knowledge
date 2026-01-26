namespace Knowledge.Domain.Models
{
	public class SubKnowledgeUser : BaseEntity<Guid>
	{
        public Guid UserId { get; set; }
        public Guid SubKnowledgeId { get; set; }
		public SubKnowledge SubKnowledge { get; set; }
	}
}
