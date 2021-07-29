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
    public class GraphicCard
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
        [Column(TypeName = "varchar(3)")]
        public string Rtx { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Core_clock { get; set; }                 //1755 MHz

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "Producent is too long (max 30 char)")]
        public string Producent { get; set; }                                           //Nvidia

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "graphics processing is too long (max 30 char)")]
        public string Graphics_processing { get; set; }     //GeForce RTX 2060

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "card bus is too long (max 30 char)")]
        public string Card_bus { get; set; }                //PCI-E x16 3.0

        [Column(TypeName = "INT(6)")]
        public int Memory_size { get; set; }                // 1024 {Mb}

        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "memory type is too long (max 10 char)")]
        public string Memory_type { get; set; }             //GDDR6

        [Column(TypeName = "INT(5)")]
        public int Memory_bus { get; set; }                 //192{-bit}

        [Column(TypeName = "INT(6)")]
        public int? Cuda_cores { get; set; }                 //1920

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "cooling is too long (max 30 char)")]
        public string Cooling { get; set; }                 //aktywne


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OutputsSTR { get; set; }
        [NotMapped]
        public string[] Outputs
        {
            get
            {
                string[] tab = this.OutputsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.OutputsSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Graphic_apiSTR { get; set; }
        [NotMapped]
        public string[] Graphic_api
        {
            get
            {
                string[] tab = this.Graphic_apiSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Graphic_apiSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "power connectors is too long (max 30 char)")]
        public string Power_connectors { get; set; }        //1x 8-pin

        [Column(TypeName = "INT(5)")]
        public int? Recommended_psu { get; set; }            //500 W

        [Column(TypeName = "INT(5)")]
        public int? Tdp { get; set; }                        //160 W

        [Column(TypeName = "INT(6)")]
        public int Length { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Width { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Heigth { get; set; }


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
                this.AccessoriesSTR =(value is null)?null: string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "code is too long (max 30 char)")]
        public string Code { get; set; }                    //GV-N2060OC-6GD rev 2.0
    }
}
