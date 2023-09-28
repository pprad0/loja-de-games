using lojadegames.Data;
using lojadegames.Model;
using Microsoft.EntityFrameworkCore;

namespace lojadegames.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {

        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                .Include(t => t.Produto)
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {

                var Categoria = await _context.Categorias
                    .Include(t => t.Produto)
                    .FirstAsync(i => i.Id == id);

                return Categoria;

            }
            catch
            {
                return null;
            }

        }

        public async Task<IEnumerable<Categoria>> GetByDescricao(string descricao)
        {
            var Categoria = await _context.Categorias
                            .Include(t => t.Produto)
                            .Where(t => t.Descricao.Contains(descricao))
                            .ToListAsync();

            return Categoria;
        }

        public async Task<Categoria?> Create(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> Update(Categoria categoria)
        {
            var TemaUpdate = await _context.Categorias.FindAsync(categoria.Id);

            if (TemaUpdate is null)
                return null;

            _context.Entry(TemaUpdate).State = EntityState.Detached;
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return categoria;

        }

        public async Task Delete(Categoria categoria)
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();

        }

    }
}
