using System.ComponentModel.DataAnnotations.Schema;

namespace ICL.Models
{
    public class Solicitud: MiClaseBase
    {
        public int ClienteId { get; set; }

        public DateTime FechaDeEntrega { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        // Relación con Postulantes (una solicitud puede tener varios postulantes)
        public List<PedidoPostulante> PedidoPostulante { get; set; } = new List<PedidoPostulante>();

        public Cliente? Cliente { get; set; }


    }
}
