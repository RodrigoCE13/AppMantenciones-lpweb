// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function confirmarEliminarMarca(id) {
    Swal.fire({
        title: 'Eliminar',
        text: "Esta seguro de eliminar la marca",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            window.location.href = "/Marca/Delete/" + id;

        }
    })

    return false;
}
function confirmarEliminarTipo(id) {
    Swal.fire({
        title: 'Eliminar',
        text: "Esta seguro de eliminar el tipo",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            window.location.href = "/TipoMantencion/Delete/" + id;

        }
    })

    return false;
}
function confirmarEliminarVehiculo(id) {
    Swal.fire({
        title: 'Eliminar',
        text: "Esta seguro de eliminar el vehiculo0",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            window.location.href = "/Vehiculo/Delete/" + id;

        }
    })

    return false;
}
function confirmarEliminarTaller(id) {
    Swal.fire({
        title: 'Eliminar',
        text: "Esta seguro de eliminar el mecanico/taller",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            window.location.href = "/Taller/Delete/" + id;

        }
    })

    return false;
}
function confirmarEliminarMantencion(id) {
    Swal.fire({
        title: 'Eliminar',
        text: "Esta seguro de eliminar la mantencion",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            window.location.href = "/Mantencion/Delete/" + id;

        }
    })

    return false;
}