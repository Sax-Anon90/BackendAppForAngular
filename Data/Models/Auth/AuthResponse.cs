using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Auth
{
    public class AuthResponse
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
    }
}
