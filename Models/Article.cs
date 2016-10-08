using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net.Bjvl.Models
{
    [Table("Article")]
    public class Article : BaseModel<Article>
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string TitleFontColor { get; set; }

        public string Author { get; set; }

        public string CopyFrom { get; set; }

        public int CategoryId { get; set; }

        public string Keyword { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public int Views { get; set; }

        public bool IsForbidden { get; set; }

        public bool IsTop { get; set; }

        public bool IsAdviced { get; set; }

        public bool IsSlider { get; set; }

        public string Thumble { get; set; }

        public int PageWords { get; set; }

        public int CreatorId { get; set; }

        public string CreatorName { get; set; }

        public string LinkUrl { get; set; }

        public string Vote { get; set; }

        public string Authority { get; set; }

        public string VideoUrl { get; set; }

        public Category Category { get; set; }
    }
}