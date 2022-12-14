using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistemaRH.Models;

namespace sistemaRH.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<ValorHora> ValorHoras { get; set; }

    }
}