$(document).ready(function () {
    bindDatatable();
});

function bindDatatable() {
    datatable = $('#tblStudent')
        .DataTable({
            "sAjaxSource": "/Complaints/Index",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "emptyTable": "No record found.",
                "processing":
                    '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
            },
            "columns": [
                {
                    "data": "TitleComplaint",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "DescComplaint",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "PropBeneficiarie",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "CompDate",
                    "autoWidth": true,
                    "searchable": true
                }, {
                    "data": "CompDate",
                    "autoWidth": true,
                    "searchable": true
                },
            ]
        });
}



//$(function () {

//    $('.dataTables_filter input').attr('placeholder', 'Search...').hide();
//    var table = $("#peopleTable").DataTable({
//        "processing": true, // for show progress bar
//        "serverSide": true, // for process server side
//        "filter": true, // this is for disable filter (search box)
//        "orderMulti": false, // for disable multiple column at once
//        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
//        "ajax": {
//            "url": '@Url.Action("getPeople", "home")',
//            "type": "POST",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "firstName", "name": "firstName", "autoWidth": true },
//            { "data": "middleName", "name": "middleName", "autoWidth": true },
//            { "data": "lastName", "name": "lastName", "autoWidth": true },
//            { "data": "emailAddress", "name": "emailAddress", "autoWidth": true },
//            { "data": "phone", "name": "phone", "autoWidth": true },
//            { "data": null, "name": "Action", "defaultContent": '<a href="#" class="editLink"><i class="fa fa-edit"></i></a> | <a href="#" class="viewLink"><i class="fa fa-eye"></i></a>', "autoWidth": true }

//        ]

//    });

//    $('.search-input').on('keyup change', function () {
//        var index = $(this).attr('data-column'),
//            val = $(this).val();
//        table.columns(index).search(val.trim()).draw();
//    });


//});