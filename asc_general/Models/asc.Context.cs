﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asc_general.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ascEntities1 : DbContext
    {
        public ascEntities1()
            : base("name=ascEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<blog_category> blog_category { get; set; }
        public virtual DbSet<cartoon> cartoons { get; set; }
        public virtual DbSet<edu_categories> edu_categories { get; set; }
        public virtual DbSet<education> educations { get; set; }
        public virtual DbSet<food> foods { get; set; }
        public virtual DbSet<gym_blog> gym_blog { get; set; }
        public virtual DbSet<health_staff> health_staff { get; set; }
        public virtual DbSet<idman_kompp> idman_kompp { get; set; }
        public virtual DbSet<lettr> lettrs { get; set; }
        public virtual DbSet<name> names { get; set; }
        public virtual DbSet<food_categories> food_categories { get; set; }
    }
}
