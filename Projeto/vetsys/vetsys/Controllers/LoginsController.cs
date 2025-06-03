using Microsoft.AspNetCore.Mvc;
using vetsys.Models;
using System.Collections.Generic;
using System.Linq;

namespace vetsys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // Simulação de base de dados (poderia ser substituído por um banco real)
        private static List<Cadastro> usuarios = new List<Cadastro>
        {
            new Cadastro { Nome = "Ana", Sobrenome = "Silva", Email = "ana@email.com", Senha = "123456", ConfirmarSenha = "123456" }
        };

        [HttpPost]
        public ActionResult Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = usuarios.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);

            if (usuario == null)
                return Unauthorized("E-mail ou senha inválidos.");

            return Ok($"Bem-vindo(a), {usuario.Nome}!");
        }
    }
}
