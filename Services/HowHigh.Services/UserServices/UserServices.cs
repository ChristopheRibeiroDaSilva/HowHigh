using HowHigh.Models.DataContext;
using HowHigh.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHighServices.UserServices
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
                var alreadyExist = _dbContext.Users.Where(u => u.pseudo == user.pseudo || u.mail == user.mail).FirstOrDefault();
                if (alreadyExist == null)
                {
                    _dbContext.Add(user);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return await Task.FromException<bool>(ex);
            }
        }
        public async Task<Users?> UpdateUser(Users user)
        {
            try
            {
                var userExist = _dbContext.Users.Find(user.id);
                if (userExist != null)
                {
                    _dbContext.Remove(userExist);
                    _dbContext.Add(user);
                    await _dbContext.SaveChangesAsync();
                    return user;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return await Task.FromException<Users?>(ex);
            }
        }
        public async Task<bool> DeleteUser(long id)
        {
            try
            {
                var userExist = _dbContext.Users.Find(id);
                if (userExist != null)
                {
                    _dbContext.Remove(userExist);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return await Task.FromException<bool>(ex);
            }
        }
        public Task<Users?> GetUser(long id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.id == id);
                return Task.FromResult(user);
            }
            catch (Exception ex)
            {
                return Task.FromException<Users?>(ex);
            }
        }
        public Task<Users?> Login(string pseudo, string userpassword)
        {
            try
            {
                var user = _dbContext.Users.Where(u => u.pseudo == pseudo)
                                           .Where(u => u.password == userpassword)
                    .FirstOrDefault();
                return Task.FromResult(user);
            }
            catch (Exception ex)
            {
                return Task.FromException<Users?>(ex);
            }
        }

    }
}
