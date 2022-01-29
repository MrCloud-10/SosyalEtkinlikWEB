using Microsoft.EntityFrameworkCore;
using SosyalEtkinlikWEB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosyalEtkinlikWEB.Context
{
    public class EtkinlikDBContext : DbContext
    {

        public EtkinlikDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SosyalEtkinlikDBWEB;Trusted_Connection=True;MultipleActiveResultSets=True");//Server name yeniden isimlendirme gerektirebilir
        }

        public EtkinlikDBContext(DbContextOptions<EtkinlikDBContext> options) : base(options)
        { }
        public DbSet<Etkinlikler> Etkinlikler { get; set; }
        public DbSet<Satis> Satis { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
    }
}