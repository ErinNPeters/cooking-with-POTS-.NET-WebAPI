using backend.Models.DataLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Dto
{
    public class RecipePreParse
    {
        [StringLength(100)]
        public string Title { get; set; } = null!;

        public DateTime Created { get; set; }

        [StringLength(100)]
        public string? SauceName { get; set; }

        public bool? CrockPot { get; set; }

        public string Ingredients { get; set; }

        public string Steps { get; set; } 
    }
}
