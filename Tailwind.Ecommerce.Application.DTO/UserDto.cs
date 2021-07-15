using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class UserDto
    {
        public int userId { get; set; }
        public string userCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public Boolean remember { get; set; }
    }
}
