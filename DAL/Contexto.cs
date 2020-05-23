using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea2.Entidades;

namespace Tarea2.DAL
{
    class Contexto :DbContext
    {

        public DbSet<Personas> Personas{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Database.db");
        }
    }
}
