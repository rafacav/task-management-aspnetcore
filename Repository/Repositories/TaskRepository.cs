using Common.Enum;
using Repository.Entities;
using Repository.Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class TaskRepository
    {
        private TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public List<Task> GetTasks(string username)
        {
            return _context.Tasks.Where(task => task.Username == username).ToList();
        }

        public Task GetTask(int id)
        {
            var query = from tasks in _context.Tasks
                        where tasks.Id == id
                        select tasks;

            var task = query.FirstOrDefault();            

            return task;
        }

        public Task CreateTask(Task task)
        {
            _context.Tasks.Add(task);

            _context.SaveChanges();

            return task;
        }

        public Task UpdateTask(Task task, TaskStatusEnum status)
        {
            task.Status = status.ToString("g");

            _context.SaveChanges();

            return task;
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);

            _context.SaveChanges();
        }
    }
}
