using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class SimpleUserInfo
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsLogged { get; set; }
        public string UserAddress { get; set; }
        public string UserRole { get; set; }
    }
}
