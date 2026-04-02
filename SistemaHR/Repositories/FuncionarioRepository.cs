using Microsoft.EntityFrameworkCore;
using SistemaHR.Data;
using SistemaHR.Models;

namespace SistemaHR.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        //injeção de dependência do DbContext para acessar o banco
        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionarios>> buscarTodosAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionarios?> buscarPorIdAsync(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task AdicionarAsync(Funcionarios funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
        }

        public void Atualizar(Funcionarios funcionario)
        {
            _context.Funcionarios.Update(funcionario);
        }

        public void Remover(Funcionarios funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
        }

        public async Task<bool> SalvarAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
