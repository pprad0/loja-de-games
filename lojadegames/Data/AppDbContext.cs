using lojadegames.Model;
using Microsoft.EntityFrameworkCore;

namespace lojadegames.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(t => t.Produto)
                .HasForeignKey("CategoriaId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Produto>()
               .HasOne(p => p.Usuario)
               .WithMany(u => u.Produto)
               .HasForeignKey("UsuarioId")
               .OnDelete(DeleteBehavior.Cascade);

        }

        // Registrar DbSet - Objeto responsável por manipular a Tabela

        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


    }

}
