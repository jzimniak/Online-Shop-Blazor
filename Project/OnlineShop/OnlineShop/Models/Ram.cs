using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Ram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProductID { get; set; }
       
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PhotoSTR { get; set; }
    [NotMapped]
        public string[] Photo
        {
            get
            {
                string[] tab = this.PhotoSTR?.Split('`');
                return tab;
            }
            set
            {
                this.PhotoSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "series is too long (max 30 char)")]
        public string Series { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "memory type is too long (max 30 char)")]
        public string Memory_type { get; set; }

        [Column(TypeName ="INT(6)")]
        public int Memory_size_full { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Memory_size_single { get; set; }

        [Column(TypeName = "INT(2)")]
        public int Items { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "frequency is too long (max 30 char)")]
        public string Frequency { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "cycle latency is too long (max 30 char)")]
        public string Cycle_latency { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "timings is too long (max 30 char)")]
        public string Timings { get; set; }

        [Column(TypeName = "double(5,2)")]
        public float Tension { get; set; }                    //1,35 V

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "cooling is too long (max 30 char)")]
        public string Cooling { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string Memory_ecc { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string Memory_backlight { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "additional_information is too long (max 30 char)")]
        public string Additional_information { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "color is too long (max 30 char)")]
        public string Color { get; set; }

    }
}
