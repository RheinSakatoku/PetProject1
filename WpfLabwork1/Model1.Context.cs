﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfLabwork1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Laba6Entities : DbContext
    {
        public Laba6Entities()
            : base("name=Laba6Entities")
        {
        }

        private static Laba6Entities _context;

        public static Laba6Entities GetContext()
        { 
            if (_context == null)
                _context = new Laba6Entities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientService> ClientService { get; set; }
        public virtual DbSet<DocumentByService> DocumentByService { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhoto { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
    }
}
