using AloneCoreApp.Data.Enums;
using AloneCoreApp.Data.Interfaces;
using AloneCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("Advertistments")]
    public class Advertistment : DomainEntities<int>, ISwitchable, ISortable
    {
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(20)]
        public string PositionId { get; set; }

        public Status Status { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }

        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }
    }
}