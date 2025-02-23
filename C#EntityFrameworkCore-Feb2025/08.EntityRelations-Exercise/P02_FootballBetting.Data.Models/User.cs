using System;
namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.User;


    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required] //Not NULL
        [MaxLength(UserUserNameMaxLength)]
        public string Username { get; set; } = null!;

        [Required] //Not NULL
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required] //Not NULL
        [MaxLength(UserPasswordMaxLength)]
        public string Password { get; set; } = null!;

        [Required] //Not NULL
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
            = new HashSet<Bet>();
    }

}

