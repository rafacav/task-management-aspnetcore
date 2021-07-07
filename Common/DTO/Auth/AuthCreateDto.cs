using System.ComponentModel.DataAnnotations;

namespace Common.DTO.Auth
{
    public class AuthCreateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set;  }
    }
}
