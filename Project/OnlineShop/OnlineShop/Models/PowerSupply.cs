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
    public class PowerSupply
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
        [Column(TypeName = "INT(5)")]
        public int Power { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "standard is too long (max 30 char)")]
        public string Standard { get; set; }

        [Column(TypeName = "varchar(60)")]
        [StringLength(60, ErrorMessage = "efficiency is too long (max 60 char)")]
        public string Efficiency { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "certificate is too long (max 30 char)")]
        public string Certificate { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "cables types is too long (max 30 char)")]
        public string Cables_types { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "fan is too long (max 30 char)")]
        public string Fan { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "pfc is too long (max 30 char)")]
        public string Pfc { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ConnectorsSTR { get; set; }
        [NotMapped]
        public string[] Connectors
        {
            get
            {
                string[] tab = this.ConnectorsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.ConnectorsSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SecuritySTR { get; set; }
        [NotMapped]
        public string[] Security
        {
            get
            {
                string[] tab = this.SecuritySTR?.Split('`');
                return tab;
            }
            set
            {
                this.SecuritySTR = (value is null) ? null : string.Join('`', value);
            }
        }

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
        [Column(TypeName = "INT(6)")]
        public int Length { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Width { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Heigth { get; set; }


        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "color is too long (max 30 char)")]
        public string Color { get; set; }
    }
}
