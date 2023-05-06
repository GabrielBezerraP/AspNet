using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCrudAspNet.Models;
using MyCrudAspNet.Repositorios;
using MyCrudAspNet.Repositorios.Interfaces;

namespace MyCrudAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _usuarioRepositorio = UsuarioRepositorio;
        }

        #region Busca por Todos usuarios já cadastrados
        [HttpGet("BuscarTodosUsuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();  
            return Ok(usuarios);
        }
        #endregion

        #region Busca por um unico usuario já cadastrado 
        [HttpGet("BuscarporId")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }
        #endregion

        #region Cadastra um novo usuário
        [HttpPost("CadastrarUsuario")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
        #endregion

        #region Remove um usuário especifico
        [HttpPost("RemoverUsuario")]
        public async Task<ActionResult<UsuarioModel>> Remover(int id)
        {
            bool usuario = await _usuarioRepositorio.Apagar(id);
            return Ok(usuario);
        }
        #endregion

        #region Edita um usuário especifico
        [HttpPost("EditarUsuario")]
        public async Task<ActionResult<UsuarioModel>> Editar([FromBody] UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }
        #endregion

    }
}
