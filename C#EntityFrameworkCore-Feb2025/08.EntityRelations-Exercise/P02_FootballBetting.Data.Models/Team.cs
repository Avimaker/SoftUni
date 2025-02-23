namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Team;

    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required] //Not NULL
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(LogoUrlMaxLength)]
        public string? LogoUrl { get; set; }

        [Required] //Not NULL
        [MaxLength(InitialsMaxLength)]
        public string Initials { get; set; } = null!;

        public decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColorId))]
        public int PrimaryKitColorId { get; set; }
        //nav prop към цвета на гостуващата фланелка
        public virtual Color PrimaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        //nav prop към цвета на гостуващата фланелка
        public virtual Color SecondaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;

        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; }
            = new HashSet<Game>();

        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> AwayGames { get; set; }
            = new HashSet<Game>();

        //в един отбор може да има много играчи
        public virtual ICollection<Player> Players { get; set; }
            = new HashSet<Player>();

    }
}
