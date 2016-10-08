using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net.Bjvl.Models
{
    [Table("Category")]
    public class Category : BaseModel<Category>
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLengthAttribute(200)]
        public string SubTitle { get; set; }

        public int ParentId { get; set; }

        public int Sort { get; set; }

        [MaxLengthAttribute(250)]
        public string Keyword { get; set; }

        [DataTypeAttribute(DataType.Text)]
        public string ReadMe { get; set; }

        public bool IsMenu { get; set; }

        public bool IsIndex { get; set; }

        public int ShowIndexCount { get; set; }

        public bool ShowIndexImg { get; set; }

        public bool IsLink { get; set; }

        [MaxLengthAttribute(250)]
        public string Url { get; set; }

        [MaxLengthAttribute(50)]
        public string Target { get; set; }

        public bool AllowUser { get; set; }

        [MaxLengthAttribute(200)]
        public string Authority { get; set; }

    }
}