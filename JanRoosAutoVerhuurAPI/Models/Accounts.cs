using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JanRoosAutoVerhuurAPI.Models
{
    public class Accounts
    {
        [Key] public int ID { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password_hash { get; set; }
        [Required] public DateTime Birthdate { get; set; }
        [Required] public string Created_at { get; set; }
    }
}
