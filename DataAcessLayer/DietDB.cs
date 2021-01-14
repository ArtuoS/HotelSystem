using DataAcessLayer;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common
{
    public class DietDB : DbContext
    {

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Food_Category> Categories { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Food_Diet> Foods_Diets { get; set; }
        public DbSet<Meal_Diet> Meals_Diets { get; set; }
        public DbSet<Meal_Food> Meals_Foods { get; set; }
        public DbSet<User_Diet> Users_Diets { get; set; }
        public DbSet<User_Restriction> Users_Restrictions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\Users\Entra21\Documents\DietDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //protected internal virtual void OnModelCreating(DBModelBuilder modelBuilder)
        //{
        //    //Criação de uma CONFIGURAÇÃO que diz que a partir de agoraz
        //    //o EF mapeará strings utilizando NOT NULL e VARCHAR.
        //    modelBuilder..Properties.ContextType.Assembly.Where(c => c.PropertyType == typeof(string)).Configure(c => c.IsRequired().IsUnicode(false));
        //
        //    modelBuilder.Properties().Where(c => c.PropertyType == typeof(string)).Configure(c => c.HasColumnType("DATETIME2"));
        //
        //    //Adiciona todas as configurações existentes no projeto DAL
        //    modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        //
        //    //Adiciona todas as convenções existentes no projeto DAL
        //    modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
        //
        //    base.OnModelCreating(modelBuilder);
        //}


        
    }

    //class CPFConvention : Convention
    //{
    //    public CPFConvention()
    //    {
    //        this.Properties().Where(C => C.PropertyType == typeof(string) && C.Name == "CPF").Configure(c => c.IsFixedLength().HasMaxLength(11));
    //    }
    //}

}