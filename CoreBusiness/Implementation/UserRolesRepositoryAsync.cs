using CoreBusiness.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Implementation
{
    public class UserRolesRepositoryAsync : IUserRolesRepositoryAsync
    {
        private readonly AppDbContext _dbContext;
        public UserRolesRepositoryAsync(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<IEnumerable<string>> GetUserRolesAsync(int userId)
        {
            var roleNames = await _dbContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .AsSingleQuery()
                .Select(x => x.Role.Name)
                .ToListAsync();

            return roleNames is null ? Enumerable.Empty<string>() : roleNames;
        }
    }
}
