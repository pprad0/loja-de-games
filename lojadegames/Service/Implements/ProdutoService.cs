using lojadegames.Data;
using lojadegames.Model;
using Microsoft.EntityFrameworkCore;

namespace lojadegames.Service.Implements
{
    public class ProdutoService : IProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {


            return await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);

                return Produto;
            }
            catch
            {
                return null;
            }

        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _context.Produtos
                                .Include(p => p.Categoria)
                                .Where(p => p.Nome.Contains(nome))
                                .ToListAsync();

            return Produto;
        }


        public async Task<Produto?> Create(Produto produto)
        {

            if (produto.Categoria is not null)
            {
                var BuscaTema = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscaTema is null)
                    return null;

                produto.Categoria = BuscaTema;

            }
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }



        public async Task<Produto?> Update(Produto produto)
        {
            var PostagemUpdate = await _context.Produtos.FindAsync(produto.Id);

            if (PostagemUpdate is null)
                return null;

            if (produto.Categoria is not null)
            {
                var BuscaTema = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscaTema is null)
                    return null;

                produto.Categoria = BuscaTema;
            }

            _context.Entry(PostagemUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return produto;

        }

        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();

        }

    }
}
