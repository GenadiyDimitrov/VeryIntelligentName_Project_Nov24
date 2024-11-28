using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeryIntelligentName.Data.Models;
using static VeryIntelligentName.Common.EntityValidationConstants.Character;

namespace VeryIntelligentName.Web.ViewModels
{
    public class CharAddViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = string.Empty;

        public CharacterClass? Class { get; set; }
        public Guid ClassId { get; set; }

        public virtual IEnumerable<CharacterClass>? Classes { get; set; } = null!;

        public void OnCharSelectionChange(CharacterClass e)
        {

        }
    }
}
