using ApiGateway.Data;
using ApiGateway.Models;
using ApiGateway.Repositorio.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.Repositorio.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MyDBContext _dbContext;

        public UsuarioRepositorio(MyDBContext myDBContext)
        {
            _dbContext = myDBContext;            
        }

        public async Task<bool> Delete(int id)
        {
            var usuarioPorId = await GetById(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Post(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Put(UsuarioModel usuario, int id)
        {
            var usuarioPorId = await GetById(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
    }
}
