using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Interfaces
{
    public interface IUserRolesRepositoryAsync
    {
        Task<IEnumerable<string>> GetUserRolesAsync(int userId);
    }
}
