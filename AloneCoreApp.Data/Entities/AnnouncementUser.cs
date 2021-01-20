using AloneCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntities<int>
    {
        [Required]
        public string AnnouncementId { get; set; }

        [StringLength(450)]
        [Required]
        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}