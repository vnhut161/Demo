﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyUp.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { set; get; }

        [Key]
        [Column(TypeName = "varchar",Order = 2)]
        [MaxLength(50)]
        public string TagId { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}