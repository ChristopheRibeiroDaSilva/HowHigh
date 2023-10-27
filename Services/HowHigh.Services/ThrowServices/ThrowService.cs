using HowHigh.Models.DataContext;
using HowHigh.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HowHigh.Services.ThrowServices
{
    public class ThrowService : IThrowService
    {
        private readonly dbContext _dbContext = null;

        public ThrowService(dbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> CreateThrow(ThrowHistories throw_History)
        {
            try
            {
                var userExist = _dbContext.Users.Where(u => u.id == throw_History.id_user).FirstOrDefault();
                if (userExist != null)
                {
                    _dbContext.Add(throw_History);
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

        public async Task<List<ThrowHistories>> GetAllThrowHistories()
        {
            try
            {
                var throws = await _dbContext.ThrowHistories.ToListAsync();
                return await Task.FromResult(throws);
            }
            catch (Exception ex)
            {
                return await Task.FromException<List<ThrowHistories>>(ex);
            }
        }
        public async Task<List<ThrowHistories>?> GetThrowHistories(int id_user)
        {
            try
            {
                var userExist = _dbContext.Users.Where(u => u.id == id_user).FirstOrDefault();
                if (userExist == null)
                {
                    return null;
                }
                else { 
                var throws = await _dbContext.ThrowHistories.Where(u => u.id_user == id_user).ToListAsync();
                return await Task.FromResult(throws);
                }
            }
            catch (Exception ex)
            {
                return await Task.FromException<List<ThrowHistories>>(ex);
            }
        }
    }
}
