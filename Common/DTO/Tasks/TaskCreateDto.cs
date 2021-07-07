using Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO.Tasks
{
    public class TaskCreateDto
    {
        [Required, MinLength(1)]
        public string Title { get; set; }

        [Required, MinLength(1)]
        public string Description { get; set; }
    }
}
