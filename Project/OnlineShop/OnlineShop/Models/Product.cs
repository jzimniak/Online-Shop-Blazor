using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Services;

namespace OnlineShop.Models
{
    
    public class Product<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(100)")]
        [StringLength(100,ErrorMessage ="name is too long (max 100 char)")]
        [MinLength(2, ErrorMessage = "name is too short (min 2 char)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="double(8,2)")]
        public float Price { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        [StringLength(50, ErrorMessage = "brand is too long (max 50 char)")]
        [MinLength(2, ErrorMessage = "brand is too short (min 2 char)")]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "warranty is too long (max 50 char)")]
        [MinLength(2, ErrorMessage = "warranty is too short (min 2 char)")]
        public string Warranty { get; set; }

        public string producttype { get; set; }

        [NotMapped]
        public T Attributes { get; set; }
    }
}
