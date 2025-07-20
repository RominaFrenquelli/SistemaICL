using Xunit;
using ICL.Models; // Asegurate que apunta al namespace donde está PedidoPostulante
using System;

namespace ICL.Tests
{
    public class PedidoPostulanteTests
    {
        [Fact]
        public void CrearNuevo_DeberiaCrearPedidoValido()
        {
            // Arrange
            var nombre = "Dora";
            var apellido = "Lopez";
            var dni = "12345678";
            var fechaNacimiento = new DateTime(1990, 5, 10);
            var observaciones = "Ninguna";
            var solicitudId = 1;
            var serviciosId = new List<int> { 2, 3 };

            // Act
            var pedido = PedidoPostulante.CrearNuevo(nombre, apellido, dni, fechaNacimiento, observaciones, solicitudId, serviciosId);

            // Assert
            Assert.NotNull(pedido);
            Assert.Equal(nombre, pedido.Nombre);
            Assert.Equal(apellido, pedido.Apellido);
            Assert.Equal(dni, pedido.DNI);
            Assert.Equal(EstadoPedido.Ingresado, pedido.Estado);
            Assert.True(pedido.FechaDeIngreso.Date == DateTime.Now.Date);
        }

        [Fact]
        public void CrearNuevo_DeberiaLanzarExcepcion_SiEsMenorDeEdad()
        {
            // Arrange
            var nombre = "Lucas";
            var apellido = "Gomez";
            var dni = "87654321";
            var fechaNacimiento = DateTime.Today.AddYears(-16); // Menor de 18
            var observaciones = "";
            var solicitudId = 1;
            var serviciosId = new List<int> { 1 };

            // Act & Assert
            var ex = Assert.Throws<Exception>(() =>
                PedidoPostulante.CrearNuevo(nombre, apellido, dni, fechaNacimiento, observaciones, solicitudId, serviciosId)
            );

            Assert.Equal("El postulante debe ser mayor de 18 años.", ex.Message);
        }

        [Fact]
        public void AsignarRedactor_DeberiaLanzarError_SiEstadoNoEsIngresado()
        {
            // Arrange
            var pedido = PedidoPostulante.CrearNuevo(
                "Ana", "Torres", "22222222",
                new DateTime(1990, 1, 1), "Obs", 1, new List<int> { 1 }
            );

            // Forzamos el cambio de estado
            pedido.AsignarRedactor(5); // Primera asignación válida

            // Act & Assert: ya no está en estado Ingresado
            var ex = Assert.Throws<InvalidOperationException>(() =>
                pedido.AsignarRedactor(10)
            );

            Assert.Contains("No se puede asignar un redactor", ex.Message);
        }
    }
}
