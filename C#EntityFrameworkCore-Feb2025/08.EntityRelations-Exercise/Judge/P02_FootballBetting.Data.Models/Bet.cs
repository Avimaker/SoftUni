using System;
namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using P02_FootballBetting.Data.Models.Enumerations;

    //using static Common.EntityValidationConstants.Bet;


    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;


    }
}

