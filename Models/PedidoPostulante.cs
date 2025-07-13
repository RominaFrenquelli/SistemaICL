using System.ComponentModel.DataAnnotations.Schema;

namespace ICL.Models
{
    public class PedidoPostulante : MiClaseBase
    {
        public string? CodigoPedido { get; private set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? DNI { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeIngreso { get; private set; }
        public DateTime FechaDeEntrega { get; private set; }

        public EstadoPedido Estado { get; private set; } = EstadoPedido.Ingresado;

        public string? Observaciones { get; set; } = "";

        public int SolicitudId { get; set; } //clave foranea
        public Solicitud? Solicitud { get; set; } // Propiedad de navegación

        public List<int>? ServiciosId { get; set; } //clave foranea
        public List<Servicio>? Servicios { get; set; }

        public int? RedactorId { get; set; }
        public Redactor? Redactor { get; set; }

        public int? ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        //constructor privado, vacío para EF y método de fabrica
        private PedidoPostulante() { }

        // Método de fábrica para crear un PedidoPostulante nuevo y válido
        public static PedidoPostulante CrearNuevo(string nombre, string apellido, string dni, 
            DateTime fechaDeNacimiento, string observaciones, int solicitudId, List<int> serviciosId)
        {
            var pedido = new PedidoPostulante
            {
                Nombre = nombre,
                Apellido = apellido,
                DNI = dni,
                FechaDeNacimiento = fechaDeNacimiento,
                Observaciones = observaciones,
                SolicitudId = solicitudId,
                ServiciosId = serviciosId.ToList(),
                FechaDeIngreso = DateTime.Now, 
                Estado = EstadoPedido.Ingresado,
                FechaDeEntrega = DateTime.Now.AddDays(5)

            };

            pedido.Validate();
            return pedido;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (FechaDeEntrega < FechaDeIngreso)
                throw new Exception("La fecha de entrega no puede ser anterior a la de ingreso.");

            if (string.IsNullOrWhiteSpace(DNI))
                throw new Exception("Debe ingresarse el DNI del postulante.");

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new Exception("El Apellido es obligatorio.");

            if (Edad() < 18)
                throw new Exception("El postulante debe ser mayor de 18 años.");

        }

        private int Edad()
        {
            DateTime hoy = DateTime.Today;
            DateTime nacimiento = FechaDeNacimiento;
            var años = hoy.Year - nacimiento.Year;
            if (nacimiento.Date > hoy.AddYears(-años)) años--;
            return años;
        }

        public void AsignarCodigo(string codigo)
        {
            CodigoPedido = codigo;
        }

        //public void RegistrarIngreso()
        //{
        //    FechaDeIngreso = DateTime.Now;
        //}

        public void AsignarRedactor(int redactorId)
        {
            if(Estado != EstadoPedido.Ingresado)
                throw new InvalidOperationException($"No se puede asignar un redactor a un pedido en estado '{Estado}'. Debe estar en estado 'Ingresado'.");
        
            if(redactorId <= 0)
                throw new ArgumentException("El ID del redactor no es válido.");

            RedactorId = redactorId;
            Estado = EstadoPedido.AsignadoARedactor;
        }

        

    }

    public enum EstadoPedido
    {
        Ingresado,       // Cuando se crea por primera vez
        AsignadoARedactor, // Asignado a un redactor
        EnRedaccion,     // El redactor está trabajando
        PendienteDeEvaluacionExterna, // Si necesita un proveedor externo
        EnEvaluacionExterna, // El proveedor externo está trabajando
        Redactado,       // Informe terminado por el redactor
        PendienteDeEntrega, // Listo para entregar al cliente
        Entregado,       // Entregado al cliente
        Cancelado,       // Si se cancela en cualquier etapa
        Eliminado        //Eliminación logica
    }

    


}
