using Livraria.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication.PgOutput.Messages;

namespace Livraria.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LivroAutor>()
                .HasKey(la => new { la.AutorId, la.LivroId });
            modelBuilder.Entity<LivroAutor>()
                .HasOne(l => l.Autor)
                .WithMany(al => al.Livros)
                .HasForeignKey(p => p.AutorId);
            modelBuilder.Entity<LivroAutor>()
                .HasOne(l => l.Livro)
                .WithMany(pe => pe.Autores)
                .HasForeignKey(e => e.LivroId);

           

            

            
            
        }
    }
}
