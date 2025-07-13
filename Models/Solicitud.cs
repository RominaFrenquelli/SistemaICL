using System.ComponentModel.DataAnnotations.Schema;

namespace ICL.Models
{
    public class Solicitud: MiClaseBase
    {
        public int ClienteId { get; set; }

        // Relación con Postulantes (una solicitud puede tener varios postulantes)
        public List<PedidoPostulante> Pedidos { get; set; } = new List<PedidoPostulante>();

        public Cliente? Cliente { get; set; }


    }
}
