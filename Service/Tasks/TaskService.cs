using Common.DTO.Tasks;
using Common.Enum;
using Common.Exceptions;
using Repository.Entities;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tasks
{
    public class TaskService
    {
        protected TaskRepository _tasksRepository;

        public TaskService(TaskRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public List<Task> GetTasks(string username)
        {
            return _tasksRepository.GetTasks(username);
        }

        public Task GetById(int id)
        {
            var task = _tasksRepository.GetTask(id);

            if (task == null)
            {
                throw new NotFoundException($"Task with id {id} not found.");
            }

            return task;
        }

        public Task CreateTask(TaskCreateDto taskCreateDto, string username)
        {
            var task = new Task()
            {
                Title = taskCreateDto.Title,
                Description = taskCreateDto.Description,
                Status = TaskStatusEnum.OPEN.ToString("g"),
                CreateDate = DateTime.Now,
                Username = username
            };

            return _tasksRepository.CreateTask(task);
        }

        public Task UpdateTask(int id, TaskStatusEnum status)
        {
            var task = GetById(id);

            return _tasksRepository.UpdateTask(task, status);
        }

        public void DeleteTask(int id)
        {
            var task = GetById(id);

            _tasksRepository.DeleteTask(task);
        }
    }
}
