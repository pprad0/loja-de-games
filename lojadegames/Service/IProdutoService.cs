using lojadegames.Model;

namespace lojadegames.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task<IEnumerable<Produto>> GetByNomeEConsole(string nome, string console);

        Task<IEnumerable<Produto>> GetByNomeOuConsole(string nome, string console);

        Task<IEnumerable<Produto>> GetByBetweenPreco(decimal precoInicial, decimal precoFinal);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}
