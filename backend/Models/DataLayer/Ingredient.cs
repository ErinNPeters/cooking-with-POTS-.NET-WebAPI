using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.DataLayer;

[Table("Ingredient")]
public partial class Ingredient
{
    [Key]
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public string Content { get; set; } = null!;

    public bool? SauceIngredient { get; set; }

    [ForeignKey("RecipeId")]
    [InverseProperty("Ingredients")]
    public virtual Recipe Recipe { get; set; } = null!;
}
