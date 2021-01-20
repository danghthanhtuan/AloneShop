using AloneCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("Sizes")]
    public class Size : DomainEntities<int>
    {
        [StringLength(250)]
        public string Name
        {
            get; set;
        }
    }
}