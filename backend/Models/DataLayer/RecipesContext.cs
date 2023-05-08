using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.DataLayer;

public partial class RecipesContext : DbContext
{
    public RecipesContext()
    {
    }

    public RecipesContext(DbContextOptions<RecipesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=RecipesContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasOne(d => d.Recipe).WithMany(p => p.Ingredients).HasConstraintName("FK_Recipe_Ingredient");
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasOne(d => d.Recipe).WithMany(p => p.Steps).HasConstraintName("FK_Recipe_Step");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
