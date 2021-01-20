using AloneCoreApp.Infrastructure.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : DomainEntities<string>
    {
        public string PageId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [ForeignKey("PageId")]
        public virtual AdvertistmentPage AdvertistmentPage { get; set; }

        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}