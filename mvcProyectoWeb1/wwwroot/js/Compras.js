﻿var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblCompras").DataTable({
        "ajax": {
            "url": "/Admin/Compra/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" }, 
            { "data": "proveedorId", "width": "10%" }, 
            { "data": "productoId", "width": "10%" },
            { "data": "cantidad", "width": "10%" }, 
            { "data": "precioCompra", "width": "15%" }, 
            { "data": "fechaCompra", "width": "15%" }, 
            {
                "data": "id",
                "render": function (data) {
                    
                    return `<div class="text-center">
                        <a href="/Admin/Compra/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                        <i class="far fa-edit"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/Admin/Compra/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                        <i class="far fa-trash-alt"></i> Borrar
                        </a>
                    </div>
                    `;
                }, "width": "20%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "No se encontraron registros",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?",
        text: "¡Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, borrar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                console.log(data); // Agregar esta línea para verificar el valor de data
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}
