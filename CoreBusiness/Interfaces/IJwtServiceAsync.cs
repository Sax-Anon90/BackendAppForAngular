using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Interfaces
{
    public interface IJwtServiceAsync
    {
        string GenerateSecurityToken(List<string> userRoles, int UserId);
    }
}
