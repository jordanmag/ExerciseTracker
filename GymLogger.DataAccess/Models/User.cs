using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymLogger.DataAccess.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime Created { get; set; }
    }
}
