//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FoodBuddy.Models;

//namespace FoodBuddy.DbContexts
//{
//    public class RecipeDbContext : DbContext
//    {
//        public DbSet<Recipe> Recipe { get; set; }

//        public RecipeDbContext() : base(nameOrConnectionString: "RecipeConnectionString")
//        { }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.HasDefaultSchema("public");
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}