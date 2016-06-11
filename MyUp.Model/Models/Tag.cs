using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyUp.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Id { set; get; }

        [MaxLength(50)]
        [Required]
        public string Name { set; get; }

        [MaxLength(50)]
        [Required]
        public string Type { set; get; }

     

    }
}