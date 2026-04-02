using SistemaHR.Models;

namespace SistemaHR.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionarios>> buscarTodosAsync();
        Task<Funcionarios?> buscarPorIdAsync(int id);
        Task AdicionarAsync(Funcionarios funcionario);
        void Atualizar(Funcionarios funcionario);
        void Remover(Funcionarios funcionario);

        Task<bool> SalvarAsync();
    }
}
