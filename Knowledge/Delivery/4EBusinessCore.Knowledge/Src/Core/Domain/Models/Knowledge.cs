namespace Knowledge.Domain.Models
{
    public class Knowledge : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public KnowledgeType KnowledgeType { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        //public Guid CategoryId { set; get; }
        //public LKP_KnowledgeCategory Category { get; set; }
        public ICollection<KnowledgeOrg>? OrgHierarchyIds { set; get; }
        public ICollection<KnowledgeUser>? UserIds { set; get; }
        public ICollection<SubKnowledge> SubKnowledges { get; set; }
    }
}
