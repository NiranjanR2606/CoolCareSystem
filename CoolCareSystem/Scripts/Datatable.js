function dataTableSetup(tableId) {
    $('#'+tableId+'').DataTable({
        "info": false,
        "lengthChange": false,
        "scrollX":true,
        "destroy": true,
        "columnDefs": [
            { "orderable": false, "targets": [-1,-2] }
        ]
    });
    $(".dataTables_filter").find("input").addClass("form-control mb");
    $(".dataTables_paginate").find("li").removeClass("paginate_button ");
    $(".dataTables_paginate").addClass("mt");
}
