using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext() : base("name=OracleDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(ConfigurationManager.AppSettings["DatabaseSchema"].ToString());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void OnContextCreated()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }



        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Investidor> Investidor { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Noticia> Noticia { get; set; }

    }
}