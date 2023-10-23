using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPracticaII.Client.Contrato;
using ProyectoPracticaII.Client.Models;
using ProyectoPracticaII.Client.Recursos;
using System.Security.Claims;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAndRegisterController : ControllerBase
    {
        private readonly Motored01Context _dbContext;

        public LoginAndRegisterController(Motored01Context dbContext)
        {
            _dbContext = dbContext;
        }
       

        [HttpPost]
        [Route("Registro")]

        public async Task<ActionResult<Usuario>> Registrarse(Usuario modelo)
        {
            modelo.Clave = Utilidades.EncriptarClave(modelo.Clave);


            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;

         

        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Usuario>> IniciarSesion(string correo, string clave)
        {

            Usuario usuario_encontrado = await GetUsuario(correo, Utilidades.EncriptarClave(clave));

            if (usuario_encontrado == null)
            {
                string error = "No se encontraron coinsidencias";

            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return usuario_encontrado;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

    }
}
