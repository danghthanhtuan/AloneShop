using AloneCoreApp.Data.Enums;
using AloneCoreApp.Data.Interfaces;
using AloneCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloneCoreApp.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntities<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, int? parentId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder, Status status, string seoPageTitle, string seoAlias,
            string seoKeyword, string seoDescription)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeFlag = homeFlag;
            HomeOrder = homeOrder;
            SeoAlias = seoAlias;
            Image = image;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = SeoPageTitle;
            SeoKeywords = seoKeyword;
            SeoDescription = seoDescription;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}