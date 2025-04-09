function validarFormulario() {
    // Validar el campo RazonSocial
    const razonSocial = document.getElementById("nombre").value;
    if (razonSocial.length < 3) {
        alert("El campo RazonSocial debe tener al menos 3 caracteres.");
        return false;
    }

    // Validar el campo Dirección
    const direccion = document.getElementById("direccion").value;
    if (direccion.length < 10) {
        alert("El campo Dirección debe tener al menos 10 caracteres.");
        return false;
    }

    // Validar el campo Teléfono
    const telefono = document.getElementById("telefono").value;
    if (telefono.length < 10) {
        alert("El campo Teléfono debe tener al menos 10 caracteres.");
        return false;
    }

    // Validar el campo Correo electrónico
    const correo = document.getElementById("correo").value;
    if (!correo.includes("@")) {
        alert("El campo Correo electrónico debe contener un símbolo '@'.");
        return false;
    }

    // Validar el campo Cuit
    const cuil = document.getElementById("cuil").value;
    if (cuil.length != 11) {
        alert("El campo Cuil debe tener 11 caracteres.");
        return false;
    }

    // Si todos los campos son válidos, enviar el formulario
    return true;
}
const crearCliente = async () => {

    let url = 'http://localhost:5285/api/Clientes';

    let data = {
        "id": 0,
        "razonSocial": document.getElementById("nombre").value
        "direccion": document.getElementById("direccion").value
        "correo": document.getElementById("correo").value
        "telefono": document.getElementById("telefono").value
        "cuil": document.getElementById("cuil").value
    }

    await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    });

    obtenerClientes();

}

// Asociar el evento onclick al botón Enviar

document.getElementById("btnEnviar").addEventListener("click", crearCliente);
