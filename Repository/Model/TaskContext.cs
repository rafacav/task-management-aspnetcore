using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Repository.Model
{
    public class TaskContext : DbContext
    {
        public TaskContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}