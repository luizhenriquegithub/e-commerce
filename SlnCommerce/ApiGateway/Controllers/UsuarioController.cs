using ApiGateway.Models;
using ApiGateway.Repositorio.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAll()
        {
            var usuarios = await _usuarioRepositorio.GetAll();
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetById(int id)
        {
            var usuario = await _usuarioRepositorio.GetById(id);
            return (usuario);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Post([FromBody] UsuarioModel usuarioModel)
        {
            var usuario = await _usuarioRepositorio.Post(usuarioModel);
            return Ok(usuario);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Put([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            var usuario = await _usuarioRepositorio.Put(usuarioModel, id);
            return Ok(usuario);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool deletado = await _usuarioRepositorio.Delete(id);
            return Ok(deletado);
        }


    }
}
