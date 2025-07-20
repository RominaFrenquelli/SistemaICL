namespace ICL.Models.DTOs
{
    public class PedidoPostulanteDTO
    {
        public int Id { get; set; }
        public string? CodigoPedido { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public DateTime FechaDeEntrega { get; set; }
        public string Estado { get; set; } = "Ingresado";
        public string? Observaciones { get; set; }

        public int SolicitudId { get; set; }
        public string? NombreCliente { get; set; }

        public string? NombreServicios { get; set; }
        public string? NombreRedactor { get; set; }
        public string? NombreProveedor { get; set; }

    }
}
