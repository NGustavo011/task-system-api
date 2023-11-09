using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDbContext _dbContext;
        public TaskRepository(TaskSystemDbContext taskSystemDbContext) {
            _dbContext = taskSystemDbContext;
        }
        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskFounded = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            if (taskFounded == null)
            {
                throw new Exception($"Task with id {id} not found");
            }
            _dbContext.Tasks.Remove(taskFounded);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskModel>> FindAllTasks()
        {
            return await _dbContext.Tasks
                .Include(task => task.User)
                .ToListAsync();
        }

        public async Task<TaskModel> FindById(int id)
        {
            return await _dbContext.Tasks
                .Include(task => task.User)
                .FirstOrDefaultAsync(task => task.Id == id);
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskFounded = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            if(taskFounded == null) {
                throw new Exception($"Task with id {id} not found");
            }
            taskFounded.Name = task.Name;
            taskFounded.Description = task.Description;
            taskFounded.Status = task.Status;
            taskFounded.UserId = task.UserId;
            _dbContext.Tasks.Update(taskFounded);
            await _dbContext.SaveChangesAsync();
            return taskFounded;
        }
    }
}
