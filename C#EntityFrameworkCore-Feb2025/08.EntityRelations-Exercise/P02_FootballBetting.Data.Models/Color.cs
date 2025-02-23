namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Color;


    public class Color
	{
        [Key]
        public int ColorId { get; set; }

        [Required] //Not NULL
        [MaxLength(ColorNameMaxLength)]
        public string Name { get; set; } = null!;

        //мап по нав проп
        [InverseProperty(nameof(Team.PrimaryKitColor))] 
        public virtual ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();

        //мап по нав проп
        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();

    }

}

