using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeryIntelligentName.Data.Models;

namespace VeryIntelligentName.Data.Configurations
{
    public class CharacterClassConfiguration : IEntityTypeConfiguration<CharacterClass>
    {
        public void Configure(EntityTypeBuilder<CharacterClass> builder)
        {
            builder.HasData(this.GenerateCharacterClass());
        }

        private IEnumerable<CharacterClass> GenerateCharacterClass()
        {
            IEnumerable<CharacterClass> cinemas =
            [
                new ()
                {
                    Name = "Wizard",
                    ClassName = "Wizard",
                    ATK = 12, //18
                    CON = 10, //5
                    DEX = 8, //4.8
                    AtkModifier = 1.5,
                    ConModifier = 0.5,
                    DexModifier = 0.6,
                    Level= 1,
                    InitiativeModifier = 1.5,
                },
                new ()
                {
                    Name = "Thief",
                    ClassName = "Thief",
                    ATK = 10, //8
                    CON = 10, //8
                    DEX = 10, //10
                    AtkModifier = 0.8,
                    ConModifier = 0.8,
                    DexModifier = 1,
                    Level= 1,
                    InitiativeModifier = 1,
                },
                new ()
                {
                    Name = "Warrior",
                    ClassName = "Warrior",
                    ATK = 11, //11
                    CON = 11, //11
                    DEX = 8, //4.8
                    AtkModifier = 1,
                    ConModifier = 1,
                    DexModifier = 0.6,
                    Level= 1,
                    InitiativeModifier = 1,
                }
            ];

            return cinemas;
        }
    }
}
