using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Description
    {
        [Required]
        public int productID { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TitleSTR { get; set; }
        [NotMapped]
        public string[] Title
        {
            get
            {
                string[] tab = this.TitleSTR?.Split('`');
                return tab;
            }
            set
            {
                this.TitleSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TextSTR { get; set; }
        [NotMapped]
        public string[] Text
        {
            get
            {
                string[] tab = this.TextSTR?.Split('`');
                return tab;
            }
            set
            {
                this.TextSTR = (value is null) ? null : string.Join('`', value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PhotosSTR { get; set; }
        [NotMapped]
        public string[] Photos
        {
            get
            {
                string[] tab = this.PhotosSTR?.Split('`');
                return tab;
            }
            set
            {
                this.PhotosSTR = (value is null) ? null : string.Join('`', value);
            }
        }
    }
}
