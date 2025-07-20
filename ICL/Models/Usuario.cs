namespace ICL.Models
{
    public class Usuario : MiClaseBase
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string ClaveHash { get; set; }
        public RolUsuario Rol { get; set; }
    }

    public enum RolUsuario
    {
        Admin,
        Redactor,
        Cliente,
        Facturacion
    }
}
