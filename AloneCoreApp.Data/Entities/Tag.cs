using AloneCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace AloneCoreApp.Data.Entities
{
    public class Tag : DomainEntities<string>
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}