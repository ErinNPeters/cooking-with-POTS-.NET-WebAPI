using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.DataLayer;

[Table("Recipe")]
public partial class Recipe
{
    [Key]
    public int RecipeId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(150)]
    public string UserId { get; set; } = null!;

    [StringLength(150)]
    public string UserName { get; set; } = null!;

    public DateTime Created { get; set; }

    [StringLength(100)]
    public string? SauceName { get; set; }

    public bool? CrockPot { get; set; }

    [InverseProperty("Recipe")]
    public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    [InverseProperty("Recipe")]
    public virtual List<Step> Steps { get; set; } = new List<Step>();
}
