using Microsoft.EntityFrameworkCore;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Entrega> Entregas { get; set; } = null!;
        public DbSet<Ocorrencia> Ocorrencias { get; set; } = null!;
        public DbSet<Canhoto> Canhotos { get; set; } = null!;
        public DbSet<Acao> Acoes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(b =>
            {
                b.HasKey(u => u.Id);
                b.Property(u => u.Nome).HasMaxLength(200);
                b.HasMany(u => u.Entregas).WithOne(e => e.Usuario).HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.SetNull);
                b.HasMany(u => u.Acoes).WithOne(a => a.Usuario).HasForeignKey(a => a.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Entrega>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.CodigoRastreio).HasMaxLength(100);
                b.HasOne(e => e.Canhoto).WithOne(c => c.Entrega).HasForeignKey<Canhoto>(c => c.EntregaId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(e => e.Ocorrencias).WithOne(o => o.Entrega).HasForeignKey(o => o.EntregaId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Ocorrencia>(b =>
            {
                b.HasKey(o => o.Id);
                b.Property(o => o.Descricao).HasMaxLength(1000);
            });

            modelBuilder.Entity<Canhoto>(b =>
            {
                b.HasKey(c => c.Id);
                b.Property(c => c.Assinante).HasMaxLength(200);
            });

            modelBuilder.Entity<Acao>(b =>
            {
                b.HasKey(a => a.Id);
                b.Property(a => a.Nome).HasMaxLength(200);
            });
        }
    }
}