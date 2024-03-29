﻿using DevTraining.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevTraining.Data.Context
{
    /// <summary>
    /// Gerando Abstração das entidades.   
    /// gerar scripts: Script-Migration -Context DevTrainingContext
    /// Add-Migration Initial -Verbose -Context DevTrainingContext
    /// Update-Database -Context DevTrainingContext
    /// Utilizar todos os pacotes na versão (3.1.14)
    /// </summary>
    public class DevTrainingContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DevTrainingContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(e => e.GetProperties()
                   .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevTrainingContext).Assembly);

            //desabilitando a exclusão via            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }


    }
}
