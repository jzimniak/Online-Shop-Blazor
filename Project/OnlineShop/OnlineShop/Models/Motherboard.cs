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
    public class Motherboard
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
        [StringLength(30, ErrorMessage = "socket is too long (max 30 char)")]
        public string Socket { get; set; }                              //Socket 1200

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "chipset is too long (max 30 char)")]
        public string Chipset { get; set; }                             //Intel Z490


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Arch_processSTR { get; set; }
        [NotMapped]
        public string[] Arch_process                                     //Comet Lake (10 generacja);Rocket Lake (11 generacja)
        {
            get
            {
                string[] tab = this.Arch_processSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Arch_processSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Memory_typesSTR { get; set; }
        [NotMapped]
        public string[] Memory_types                                    //DDR4-2933 MHz (Intel Core i7/i9);DDR4-2666 MHz (Intel Core i3/i5)
        {
            get
            {
                string[] tab = this.Memory_typesSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Memory_typesSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Memory_types_ocSTR { get; set; }
        [NotMapped]
        public string[] Memory_types_oc                                 //DDR4-4800 MHz;DDR4-4600 MHz...                                        
        {
            get
            {
                string[] tab = this.Memory_types_ocSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Memory_types_ocSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "INT(2)")]
        public int Memory_slots { get; set; }                           //4 x DIMM

        [Column(TypeName = "INT(5)")]
        public int? Memory_max_size { get; set; }                        //128 {GB}

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "memory channel is too long (max 30 char)")]
        public string Memory_channel { get; set; }                      //Dual-channel


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Internal_connectionSTR { get; set; }
        [NotMapped]
        public string[] Internal_connection                              //SATA III (6 Gb/s) - 6 szt.;M.2 PCIe NVMe 3.0 x4 / SATA - 1 szt....
        {
            get
            {
                string[] tab = this.Internal_connectionSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Internal_connectionSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Back_panel_portsSTR { get; set; }
        [NotMapped]
        public string[] Back_panel_ports                                //HDMI - 1 szt.;DisplayPort - 1 szt....
        {
            get
            {
                string[] tab = this.Back_panel_portsSTR?.Split('`');
                return tab;
            }
            set
            {
                this.Back_panel_portsSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RaidSTR { get; set; }
        [NotMapped]
        public string[] Raid                                            //RAID 0;RAID 1; RAID 5 ...
        {
            get
            {
                string[] tab = this.RaidSTR?.Split('`');
                return tab;
            }
            set
            {
                this.RaidSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "multi cards is too long (max 30 char)")]
        public string Multi_cards { get; set; }                         //AMD CrossFireX

        [Column(TypeName = "varchar(3)")]
        public string Can_handle_processor_card { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "audio is too long (max 30 char)")]
        public string Audio { get; set; }                               //Realtek ALC892

        [Column(TypeName = "varchar(3)")]
        public string Wireless_connection { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "format is too long (max 30 char)")]
        public string Format { get; set; }                              //ATX

        [Column(TypeName = "INT(6)")]
        public int Width { get; set; }

        [Column(TypeName = "INT(6)")]
        public int Length { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "code is too long (max 30 char)")]
        public string Code { get; set; }
    }
}
