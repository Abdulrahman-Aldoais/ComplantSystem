$(document).ready(function () {
    $('#UploadsComplainte').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/Compalint/GetCompalints",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            { "data": "titleComplaint", "name": "TitleComplaint", "autowidth": true },
            { "data": "compDate", "name": "CompDate", "autowidth": true },
            { "data": "statusCompalintId", "name": "StatusCompalintId", "autowidth": true },
            //{ "data": "contact", "name": "Contact", "autowidth": true },
            //{ "data": "email", "name": "Email", "autowidth": true },
            //{ "data": "dateOfBirth", "name": "DateOfBirth", "autowidth": true },
            {
                "render": function (data, type, row) { return '<span>' + row.dateOfBirth.split('T')[0] + '</span>' },
                "name": "DateOfBirth"
            },
            {
                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.id + '"); > Delete </a>' },
                "orderable": false
            },

        ]
    });
});