using ApiGateway.Models;

namespace ApiGateway.Repositorio.Intefaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> Post(UsuarioModel usuario);

        Task<UsuarioModel> Put(UsuarioModel usuario, int id);
        
        Task<bool> Delete(int id);
    }
}
