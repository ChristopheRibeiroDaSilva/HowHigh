using HowHigh.Models.Models;

namespace HowHigh.Services.ThrowServices
{
    public interface IThrowService
    {
        Task<bool> CreateThrow(ThrowHistories throw_History);
        Task<List<ThrowHistories>> GetAllThrowHistories();
        Task<List<ThrowHistories>?> GetThrowHistories(int id_user);

    }
}
