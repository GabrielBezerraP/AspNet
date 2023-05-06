using Microsoft.EntityFrameworkCore;
using MyCrudAspNet.Data;
using MyCrudAspNet.Models;
using MyCrudAspNet.Repositorios.Interfaces;

namespace MyCrudAspNet.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        //Repositorio com as tarefas utilizadas requisitadas pelo Controller
        private readonly SistemaTarefasDbContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            UsuarioModel usuarioPorId = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuarioPorId == null)
            {
                throw new Exception("Usuario não encontrado, favor verificar!");
            }
            return usuarioPorId;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario; 
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception("Usuario não encontrado, favor verificar!");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null) 
            {
                throw new Exception("Usuario não encontrado, favor verificar!");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync(); 

            return usuarioPorId;
        }

    }
}
