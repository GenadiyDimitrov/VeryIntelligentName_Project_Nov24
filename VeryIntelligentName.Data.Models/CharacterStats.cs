using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static VeryIntelligentName.Common.EntityValidationConstants.CharacterClass;

namespace VeryIntelligentName.Data.Models
{
    public abstract class EnityBase
    {
        [Key]
        [Comment("Entity identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Range(MinLevel, MaxLevel)]
        [Comment("Increase stats or loot")]
        public int Level { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Name of the entity")]
        public string Name { get; set; } = null!;
    }

    public abstract class AnimateEntity : EnityBase
    {
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Name of class")]
        public string ClassName { get; set; } = null!;
        [Required]
        [Range(MinStat, int.MaxValue)]
        [Comment("Atack stat of entity")]
        public int ATK { get; set; }
        [Required]
        [Range(MinStat, int.MaxValue)]
        [Comment("Contitution stat of entity")]
        public int CON { get; set; }
        [Required]
        [Range(MinStat, int.MaxValue)]
        [Comment("Dextirity stat of entity")]
        public int DEX { get; set; }

        [Required]
        [Comment("Dependent on class")]
        public double DexModifier { get; set; }
        [Required]
        [Comment("Dependent on class")]
        public double ConModifier { get; set; }
        [Required]
        [Comment("Dependent on class")]
        public double AtkModifier { get; set; }
        [Required]
        [Comment("Dependent on class. Range classes have higher modifier")]
        public double InitiativeModifier { get; set; }
    }
    public abstract class InanimateEntity : EnityBase
    {
    }

    public class Character : AnimateEntity
    {
        [Required]
        [Comment("User it belongs to")]
        public Guid PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public ApplicationUser Player { get; set; }
    }
    public class Enemy : AnimateEntity
    {
    }


    public class CharacterClass : AnimateEntity
    {

    }
    [PrimaryKey(nameof(PlayerId), nameof(CharacterId))]
    public class PlayersCharacters
    {
        [Required]
        [Comment("User it belongs to")]
        public Guid PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public virtual ApplicationUser Player { get; set; }

        [Required]
        [Comment("Character it belongs to")]
        public Guid CharacterId { get; set; }
        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; }
    }
}
