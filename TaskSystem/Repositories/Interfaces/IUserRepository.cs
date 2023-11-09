using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
