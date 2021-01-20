using AloneCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("BlogTags")]
    public class BlogTag : DomainEntities<int>
    {
        public int BlogId { set; get; }

        public string TagId { set; get; }

        [ForeignKey("BlogId")]
        public virtual Blog Blog { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}