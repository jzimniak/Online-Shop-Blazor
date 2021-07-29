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
    public class ComputerCase
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
        [StringLength(30, ErrorMessage = "case type is too long (max 30 char)")]
        public string Type { get; set; }                             //middle tower


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Motherboards_typeSTR { get; set; }
        [NotMapped]
        public string[] Motherboards_type
        {
            get
            {
                string[] tab = this.Motherboards_typeSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Motherboards_typeSTR = (value is null) ? null : string.Join('`', value);
            }

        }
        [Column(TypeName = "INT(2)")]
        public int Extension_cards { get; set; }

        [Column(TypeName = "INT(4)")]
        public int Max_graphic_card_length { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaterialsSTR { get; set; }
        [NotMapped]
        public string[] Materials
        {
            get
            {
                string[] tab = this.MaterialsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.MaterialsSTR = (value is null) ? null : string.Join('`', value);
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
        [Column(TypeName = "varchar(30)")]
        [StringLength(100, ErrorMessage = "side panel information is too long (max 30 char)")]
        public string Side_panel { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(100, ErrorMessage = "backlight is too long (max 30 char)")]
        public string Backlight { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(100, ErrorMessage = "power supply type is too long (max 30 char)")]
        public string Power_supply_type { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Space_for_discsSTR { get; set; }
        [NotMapped]
        public string[] Space_for_discs
        {
            get
            {
                string[] tab = this.Space_for_discsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Space_for_discsSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "INT(4)")]
        public int? Max_height_of_cooling { get; set; }

        [Column(TypeName = "INT(2)")]
        public int Max_fans { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Fans_typesSTR { get; set; }
        [NotMapped]
        public string[] Fans_types
        {
            get
            {
                string[] tab = this.Fans_typesSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Fans_typesSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Water_cooling_optionsSTR { get; set; }
        [NotMapped]
        public string[] Water_cooling_options
        {
            get
            {
                string[] tab = this.Water_cooling_optionsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Water_cooling_optionsSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "INT(2)")]
        public int Fans_installed { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Fans_types_installedSTR { get; set; }
        [NotMapped]
        public string[] Fans_types_installed
        {
            get
            {
                string[] tab = this.Fans_types_installedSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Fans_types_installedSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ButtonsSTR { get; set; }
        [NotMapped]
        public string[] Buttons
        {
            get
            {
                string[] tab = this.ButtonsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.ButtonsSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Front_panel_outputsSTR { get; set; }
        [NotMapped]
        public string[] Front_panel_outputs
        {
            get
            {
                string[] tab = this.Front_panel_outputsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Front_panel_outputsSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "color type is too long (max 30 char)")]
        public string Color { get; set; }


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
        [Column(TypeName = "INT(4)")]
        public int Width { get; set; }

        [Column(TypeName = "INT(4)")]
        public int Heigth { get; set; }

        [Column(TypeName = "INT(4)")]
        public int Length { get; set; }

        [Column(TypeName = "INT(4)")]
        public float Weigth { get; set; }
    }
}
