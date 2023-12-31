﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamesCollection.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GamesCollectionEntities : DbContext
    {
        private static GamesCollectionEntities _context;
        public GamesCollectionEntities()
            : base("name=GamesCollectionEntities")
        {
        }

        public static GamesCollectionEntities GetContext()
        {
            if (_context == null)
                _context = new GamesCollectionEntities();

            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Developers> Developers { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<GamesDevelopers> GamesDevelopers { get; set; }
        public virtual DbSet<GamesGenres> GamesGenres { get; set; }
        public virtual DbSet<GamesPlatforms> GamesPlatforms { get; set; }
        public virtual DbSet<GamesPublishers> GamesPublishers { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Platforms> Platforms { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersGames> UsersGames { get; set; }
    }
}
