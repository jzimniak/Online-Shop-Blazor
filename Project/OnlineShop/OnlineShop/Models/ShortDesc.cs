using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ShortDesc
    {
        [Required]
        public int productID { get; set; }
        public string[] Title { get; set; }

        public string[] Text { get; set; }

        public IBrowserFile[] photos { get; set; }
    }
}
