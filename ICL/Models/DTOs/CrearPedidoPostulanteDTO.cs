namespace ICL.Models.DTOs
{
    public class CrearPedidoPostulanteDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Observaciones { get; set; }
        public int SolicitudId { get; set; }
        public List<int> ServiciosId { get; set; } = new();
    }
}
