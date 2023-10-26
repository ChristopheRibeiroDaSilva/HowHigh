using HowHigh.Models.DataContext;
using HowHigh.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly dbContext _dbContext = null;

        public UserServices(dbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> CreateUser(Users user)
        {
            try { 
                _dbContext.Add(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { 
                return false;
            }
        }
    }
}
