
namespace Ramto.Modelos.Response
{
    public class SimpleResponse
    {
        public bool Exito { get; set; }
        public string? Mensaje { get; set; }
        public Guid IdPersona { get; set; }
    }

    public class Apiresponse<T> : SimpleResponse where T : new()
    {
        public Apiresponse()
        {
            this.data = new T();
        }
        public T data { get; set; }
    }
}
