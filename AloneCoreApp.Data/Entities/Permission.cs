using AloneCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntities<int>
    {
        [StringLength(450)]
        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public string FunctionId { get; set; }

        public bool CanCreate { set; get; }
        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }

        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }

        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }
    }
}