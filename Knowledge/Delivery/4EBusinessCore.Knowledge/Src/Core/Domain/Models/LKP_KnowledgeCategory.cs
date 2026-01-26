namespace Knowledge.Domain.Models
{
    public class LKP_KnowledgeCategory:BaseEntity<Guid>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }
        public string CSSClasses { get; set; }
		//public virtual ICollection<Knowledge> Knowledges { get; set; }
		//public virtual ICollection<SubKnowledge> SubKnowledges { get; set; }
	}
}