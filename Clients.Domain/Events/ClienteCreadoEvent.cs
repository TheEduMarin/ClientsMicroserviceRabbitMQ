
namespace Clients.Domain.Events
{
    public class ClienteCreadoEvent
    {
        public Guid ClienteId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
