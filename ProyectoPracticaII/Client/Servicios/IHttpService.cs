namespace ProyectoPracticaII.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRepuesta<T>> Get<T>(string url);
    }
}