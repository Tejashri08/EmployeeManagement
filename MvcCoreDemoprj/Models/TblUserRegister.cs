using System;
using System.Collections.Generic;

namespace MvcCoreDemoprj.Models
{
    public partial class TblUserRegister
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CityId { get; set; }
        public string? Password { get; set; }
    }
}
