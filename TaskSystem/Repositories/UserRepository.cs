using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDbContext _dbContext;
        public UserRepository(TaskSystemDbContext taskSystemDbContext) {
            _dbContext = taskSystemDbContext;
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userFounded = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (userFounded == null)
            {
                throw new Exception($"User with id {id} not found");
            }
            _dbContext.Users.Remove(userFounded);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userFounded = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if(userFounded == null) {
                throw new Exception($"User with id {id} not found");
            }
            userFounded.Name = user.Name;
            userFounded.Email = user.Email;
            _dbContext.Users.Update(userFounded);
            await _dbContext.SaveChangesAsync();
            return userFounded;
        }
    }
}
