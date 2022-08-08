namespace PCCO.Models
{
    public partial class CriminalArticle
    {
        public CriminalArticle()
        {
            Punishments = new HashSet<Punishment>();
        }

        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }

        public virtual ICollection<Punishment> Punishments { get; set; }
    }
}
