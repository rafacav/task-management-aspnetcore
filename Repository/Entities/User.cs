using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
