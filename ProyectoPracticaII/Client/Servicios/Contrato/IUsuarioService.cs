using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;


namespace ProyectoPracticaII.Client.Contrato
{
    public interface IUsuarioService
    {

        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> Post(Usuario modelo);

    }
}
