using AloneCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("Footers")]
    public class Footer : DomainEntities<string>
    {
        [Required]
        public string Content { set; get; }
    }
}