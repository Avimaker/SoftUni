using System;
namespace P02_FootballBetting.Data.Models
{

    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Position;


    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required] //Not NULL
        [MaxLength(PositionNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Player> Players { get; set; }
            = new HashSet<Player>();
    }
    
}

