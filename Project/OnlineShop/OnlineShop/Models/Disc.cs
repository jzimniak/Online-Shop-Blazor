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
    public class Disc
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
        [Column(TypeName = "varchar(15)")]
        [StringLength(15, ErrorMessage = "destiny is too long (max 15 char)")]
        public string Destiny { get; set; }                         //pc 

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "type is too long (max 30 char)")]
        public string Type { get; set; }                            //ssd hdd

        [Column(TypeName = "INT(6)")]
        public int Capacity { get; set; }                           // 512 gb

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "format is too long (max 30 char)")]
        public string Format { get; set; }                          //2.5";M.2

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "interface is too long (max 30 char)")]
        public string Interfaces { get; set; }                      //M.2 PCIe NVMe 3.0 x4

        [Column(TypeName = "INT(6)")]
        public int Read_speed { get; set; }

        [Column(TypeName = "INT(6)")]
        public int? Write_speed { get; set; }

        [Column(TypeName = "INT(6)")]
        public int? Random_read_speed { get; set; }

        [Column(TypeName = "INT(6)")]
        public int? Random_write_speed { get; set; }

        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "memory type is too long (max 10 char)")]
        public string Memory_type { get; set; }                     //TLC

        [Column(TypeName = "INT(15)")]
        public int Reliability { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string Radiator { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Additional_informationSTR { get; set; }
        [NotMapped]
        public string[] Additional_information
        {
            get
            {
                string[] tab = this.Additional_informationSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Additional_informationSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AccessoriesSTR { get; set; }
        [NotMapped]
        public string[] Accessories
        {
            get
            {
                string[] tab = this.AccessoriesSTR?.Split('`');
                return tab;
            }
            set
            {
                this.AccessoriesSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "color is too long (max 30 char)")]
        public string Color { get; set; }

        [Column(TypeName = "INT(6)")]
        public float Width { get; set; }

        [Column(TypeName = "INT(6)")]
        public float Heigth { get; set; }

        [Column(TypeName = "INT(6)")]
        public float Length { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "code is too long (max 30 char)")]
        public string Code { get; set; }

    }
}
