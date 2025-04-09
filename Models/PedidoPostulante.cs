using System.ComponentModel.DataAnnotations.Schema;

namespace ICL.Models
{
    public class PedidoPostulante : MiClaseBase
    {
        
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? DNI { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string? Observaciones { get; set; } = "";

        public int SolicitudId { get; set; } //clave foranea

        public int ServicioId { get; set; } //clave foranea

        public Servicio? Servicio { get; set; }

        public Solicitud? Solicitud { get; set; } // Propiedad de navegación

        public void Validate()
        {

        }

    }

    
}
