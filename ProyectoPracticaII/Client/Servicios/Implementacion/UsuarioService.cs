using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProyectoPracticaII.Client.Models;
using ProyectoPracticaII.Client.Contrato;

namespace ProyectoPracticaII.Client.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly Motored01Context _dbContext;

        public UsuarioService(Motored01Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
          Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u =>  u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
          _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
