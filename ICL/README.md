# API de Gestión de Pedidos de Postulantes-SistemaICL

## Descripción General

Esta API RESTful está diseñada para gestionar el ciclo de vida completo de los pedidos de informes laborales para postulantes, desde su ingreso inicial hasta la entrega final al cliente. Sirve como el backend central para un sistema integral de evaluación de personal, facilitando la coordinación entre clientes, administradores, redactores y proveedores de evaluación.

---

## Características Principales

* **Gestión Completa de Pedidos de Postulantes (CRUD):** Creación, lectura, actualización y eliminación de solicitudes de informes.
* **Gestión de Estados Robustos:** Implementación de un ciclo de vida definido para los pedidos, con transiciones de estado controladas que reflejan el flujo de negocio (Ej: `Ingresado` -> `AsignadoARedactor` -> `EnRedaccion` -> `Redactado` -> `Entregado`).
* **Validaciones de Dominio Integradas:** Lógica de negocio crucial encapsulada directamente en la entidad `PedidoPostulante` para asegurar la integridad de los datos.
* **Generación de Códigos de Pedido Únicos:** Sistema automático para asignar identificadores únicos a cada pedido.
* **Integración con Entidades Relacionadas:** Manejo de relaciones con `Solicitud`, `Servicio`, `Redactor` y `Proveedor`.

---

## Tecnologías Utilizadas

* **Backend:** C# con .NET 6.0
* **Framework Web:** ASP.NET Core
* **ORM:** Entity Framework Core 6.0.21
* **Base de Datos:** SQL Server
* **Control de Versiones:** Git & GitHub

---

## Arquitectura y Patrones de Diseño

Este proyecto sigue una arquitectura en capas bien definida para separar las responsabilidades y promover la mantenibilidad:

* **Capa de Presentación (Controllers):** Maneja las solicitudes HTTP y coordina las respuestas de la API.
* **Capa de Negocio (Business):** Contiene la lógica de negocio principal y maneja las operaciones del dominio.
* **Capa de Datos (Repositories):** Maneja los detalles de cómo se guardan y recuperan los datos, interactuando con la base de datos a través de Entity Framework Core.

Además, se aplican principios de **Domain-Driven Design (DDD)**:

* **Rich Domain Model:** La entidad `PedidoPostulante` no es solo un contenedor de datos; encapsula su propia lógica de negocio y comportamiento (ej. métodos para cambiar de estado, validaciones internas).
* **Domain Events:** Uso de eventos de dominio para desacoplar las acciones secundarias que ocurren como resultado de un cambio de estado en una entidad (ej. notificaciones).
* **Inyección de Dependencias:** Gestión eficiente de las dependencias entre las capas para facilitar la prueba y el mantenimiento.

---

## Cómo Ejecutar el Proyecto

Sigue estos pasos para poner en marcha la API en tu entorno local:

1.  **Clonar el Repositorio:**
    ```bash
    git clone https://github.com/RominaFrenquelli/SistemaICL.git
    cd SistemaICL
    ```
2.  **Configurar la Base de Datos:**
    * Abre el archivo `appsettings.json` (o `appsettings.Development.json`) y actualiza la cadena de conexión (`ConnectionStrings:DefaultConnection`) para que apunte a tu instancia de SQL Server.
    * Ejecuta las migraciones de Entity Framework para crear la base de datos y sus tablas:
        ```bash
        dotnet ef database update
        ```
        *(Asegúrate de tener las herramientas de EF Core instaladas: `dotnet tool install --global dotnet-ef`)*
3.  **Restaurar Dependencias:**
    ```bash
    dotnet restore
    ```
4.  **Ejecutar la API:**
    ```bash
    dotnet run
    ```
    La API estará disponible en `https://localhost:7264` (o el puerto configurado si usas un perfil diferente o IIS Express).
---

## Endpoints de la API (Ejemplos)

Aquí hay algunos ejemplos de los endpoints clave de la API. Se recomienda usar una herramienta como Postman, Insomnia o Swagger UI (si lo tienes configurado) para interactuar con la API.

* `POST /api/PedidoPostulante` - Crea un nuevo Pedido de Postulante.
* `GET /api/PedidoPostulante` - Obtiene una lista de todos los Pedidos de Postulantes.
* `GET /api/PedidoPostulante/{id}` - Obtiene un Pedido de Postulante por su ID.
* `PUT /api/PedidoPostulante/{id}` - Actualiza completamente un Pedido de Postulante existente.
* `DELETE /api/PedidoPostulante/{id}` - Elimina un Pedido de Postulante.
* `PATCH /api/PedidoPostulante/{id}/asignar-redactor` - Asigna un redactor a un pedido (ejemplo de transición de estado).
* `PATCH /api/PedidoPostulante/{id}/marcar-redactado` - Marca un pedido como redactado (ejemplo de transición de estado).

---

## Contacto

* **Tu Nombre:** Romina Frenquelli
* **LinkedIn:** www.linkedin.com/in/romina-frenquelli
* **Email:** rominaf462@gmail.com

---

**Nota:** Este proyecto está en desarrollo continuo y representa una aplicación de principios de Clean Architecture y Domain-Driven Design para construir un sistema escalable y mantenible.
