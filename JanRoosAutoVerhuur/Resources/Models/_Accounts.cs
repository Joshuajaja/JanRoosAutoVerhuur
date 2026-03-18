using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JanRoosAutoVerhuur.Models
{
    public class _Accounts
    {
        [Required] public string Username { get; set; }
        [Required] public string Password_hash { get; set; }
        [Required] public DateTime Birthdate { get; set; }
        [Required] public DateTime Created_at { get; set; }
    }
}
