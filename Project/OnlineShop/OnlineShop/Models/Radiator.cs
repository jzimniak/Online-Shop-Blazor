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
    public class Radiator
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
        [StringLength(30, ErrorMessage = "TDP is too long (max 30 char)")]
        public string Cooling_type { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SocketsSTR { get; set; }
        [NotMapped]
        public string[] Sockets
        {
            get
            {
                string[] tab = this.SocketsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.SocketsSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FansSTR { get; set; }
        [NotMapped]
        public string[] Fans
        {
            get
            {
                string[] tab = this.FansSTR?.Split('`');
                return tab;
            }
            set
            {
                this.FansSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "materials is too long (max 30 char)")]
        public string Materials { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "rps is too long (max 30 char)")]
        public string Rps { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "bearing is too long (max 30 char)")]
        public string Bearing { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "max dB is too long (max 30 char)")]
        public string Max_dB { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "connectors is too long (max 30 char)")]
        public string Connectors { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string Backlight { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "service life is too long (max 30 char)")]
        public string Service_life { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "TDP is too long (max 30 char)")]
        public string Tdp { get; set; }


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
        [Column(TypeName = "INT(5)")]
        public int Heigth { get; set; }

        [Column(TypeName = "INT(5)")]
        public int Width { get; set; }

        [Column(TypeName = "INT(5)")]
        public int Length { get; set; }

        [Column(TypeName = "INT(5)")]
        public int Weight { get; set; }


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
        [StringLength(30, ErrorMessage = "code is too long (max 30 char)")]
        public string Code { get; set; }

    }
}
