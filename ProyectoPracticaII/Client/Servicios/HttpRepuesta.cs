namespace ProyectoPracticaII.Client.Servicios
{
    public class HttpRepuesta<T>
    {
        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }
        public HttpRepuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        
   
    }
}
