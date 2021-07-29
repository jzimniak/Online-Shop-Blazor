using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.User
{
    public class UserSQL
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] Salt { get; set; }
        public string Passhash { get; set; }
        public string Email { get; set; }
        public string UserAddres { get; set; }
        public string UserRole { get; set; }

    }
}
