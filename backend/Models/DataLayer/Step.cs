using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.DataLayer;

[Table("Step")]
public partial class Step
{
    [Key]
    public int StepId { get; set; }

    public int RecipeId { get; set; }

    public string Content { get; set; } = null!;

    [ForeignKey("RecipeId")]
    [InverseProperty("Steps")]
    public virtual Recipe Recipe { get; set; } = null!;
}
