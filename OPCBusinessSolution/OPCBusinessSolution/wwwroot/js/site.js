// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("btnDescargar").addEventListener('click', function () {
    // Obtener la tabla pedimento
    var tablaPedimento = document.getElementById("tblPedimento");

    // Convertir la tabla a una cadena de texto
    var data = '';
    for (var i = 0; i < tablaPedimento.rows.length; i++) {
        for (var j = 0; j < tablaPedimento.rows[i].cells.length; j++) {
            data += tablaPedimento.rows[i].cells[j].innerText + '\t';
        }
        data += '\n';
    }

    // Blob con los datos de la tabla
    var blob = new Blob([data], { type: 'text/plain' });

    // Creando el enlace para descargar el archivo
    var enlace = document.createElement('a');
    enlace.href = URL.createObjectURL(blob);
    enlace.download = '1716417755841.xls';

    // Añadir el enlace al documento y ejecutar el clic para descargar el archivo
    document.body.appendChild(enlace);
    enlace.click();

    // Eliminar el enlace del documento
    document.body.removeChild(enlace);
});
