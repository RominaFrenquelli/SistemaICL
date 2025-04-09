using System.Text.RegularExpressions;

namespace ICL.Models
{
    public class Cliente: MiClaseBase
    {
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public string? Cuil { get; set; }
        public string? Mail { get; set; }
        public string? Telefono { get; set; }
        public List<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();

        // Relación 1 a muchos: un Cliente puede tener varios PedidosPostulantes
        public List<PedidoPostulante> PedidosPostulantes { get; set; } = new List<PedidoPostulante>();

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(RazonSocial))
            {
                throw new Exception("El campo RazonSocial es obligatorio.");
            }

            if (string.IsNullOrEmpty(Direccion))
            {
                throw new Exception("El campo Dirección es obligatorio.");
            }

            if (string.IsNullOrEmpty(Mail))
            {
                throw new Exception("El campo Correo electrónico es obligatorio");
            }

            if(!Regex.IsMatch(Mail, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
            {
                throw new Exception("El correo electrónico debe ser válido e incluir '@' y un dominio como '.com'.");
            }

            if (string.IsNullOrEmpty(Telefono) || Telefono.Length <= 10)
            {
                throw new Exception("El campo Teléfono debe tener al menos 10 caracteres");
            }

            if (string.IsNullOrEmpty(Cuil) || Cuil.Length != 11)
            {
                throw new Exception("El campo Cuil debe tener 11 caracteres.");
            }
        }

      

    }
}
