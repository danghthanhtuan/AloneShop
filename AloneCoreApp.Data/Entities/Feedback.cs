using AloneCoreApp.Data.Enums;
using AloneCoreApp.Data.Interfaces;
using AloneCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("Feedbacks")]
    public class Feedback : DomainEntities<int>, ISwitchable, IDateTracking
    {
        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(250)]
        public string Email { set; get; }

        [StringLength(500)]
        public string Message { set; get; }

        public Status Status { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
    }
}