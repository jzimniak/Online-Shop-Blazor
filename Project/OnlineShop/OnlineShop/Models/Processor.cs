using Microsoft.AspNetCore.Components;
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
    public class Processor
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
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "family is too long (max 50 char)")]
        public string Family { get; set; }     //Intel Core i9

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "processor number is too long (max 50 char)")]
        public string Processor_number { get; set; }    //i9-XXXXX

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "socket is too long (max 50 char)")]
        public string Socket { get; set; }              //socket 1200

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "code_name is too long (max 50 char)")]
        public string Arch { get; set; }           //Products formerly Comet Lake

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "frequency is too long (max 50 char)")]
        public string Frequency { get; set; }           //3.6 GHz (5.2 GHz w trybie turbo)

        [Column(TypeName = "INT(3)")]
        public int Cores { get; set; }                  //10

        [Column(TypeName = "INT(3)")]
        public int Threads { get; set; }                //20

        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "cache is too long (max 10 char)")]
        public string Unlocked { get; set; }


        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "cache is too long (max 50 char)")]
        public string Cache { get; set; }               //20MB

        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "cache is too long (max 10 char)")]
        public string Intergrated_graphic { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "processor graphic is too long (max 50 char)")]
        public string Processor_graphic { get; set; }   //Intel® UHD Graphics 630

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "memory types is too long (max 50 char)")]
        public string Memory_types { get; set; }        //DDR4-2933

        [Column(TypeName = "varchar(50)")]
        [StringLength(30, ErrorMessage = "lithography is too long (max 50 char)")]
        public string Lithography { get; set; }         //14nm

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "TDP is too long (max 50 char)")]
        public string TDP { get; set; }                 //125W


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TechnologiesSTR { get; set; }
        [NotMapped]
        public string[] Technologies                    //Intel Hyper-Threading;Intel Turbo Boost 2.0;Intel Turbo Boost Max 3.0    
        {
            get
            {
                string[] tab = this.TechnologiesSTR?.Split('`');
                return tab;
            }
            set
            {
                this.TechnologiesSTR = (value is null) ? null : string.Join('`', value);
            }
        }
        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "cache is too long (max 10 char)")]
        public string Cooling_in_box { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "code is too long (max 50 char)")]
        public string Code { get; set; }                //BX8070110850K
    }
}
