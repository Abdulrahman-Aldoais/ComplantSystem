/**
 * DataTables Advanced (jquery)
 */

'use strict';

$(function () {
    var dt_filter_table = $('.dt-column-search');

    // Advanced Search Functions Starts
    // --------------------------------------------------------------------

    // Datepicker for advanced filter
    var rangePickr = $('.flatpickr-range'),
        dateFormat = 'MM/DD/YYYY';

    if (rangePickr.length) {
        rangePickr.flatpickr({
            mode: 'range',
            dateFormat: 'm/d/Y',
            orientation: isRtl ? 'auto right' : 'auto left',
            locale: {
                format: dateFormat
            },
            onClose: function (selectedDates, dateStr, instance) {
                var startDate = '',
                    endDate = new Date();
                if (selectedDates[0] != undefined) {
                    startDate = moment(selectedDates[0]).format('MM/DD/YYYY');
                    startDateEle.val(startDate);
                }
                if (selectedDates[1] != undefined) {
                    endDate = moment(selectedDates[1]).format('MM/DD/YYYY');
                    endDateEle.val(endDate);
                }
                $(rangePickr).trigger('change').trigger('keyup');
            }
        });
    }

    // Filter column wise function
    function filterColumn(i, val) {
        if (i == 5) {
            var startDate = startDateEle.val(),
                endDate = endDateEle.val();
            if (startDate !== '' && endDate !== '') {
                $.fn.dataTableExt.afnFiltering.length = 0; // Reset datatable filter
                dt_adv_filter_table.dataTable().fnDraw(); // Draw table after filter
                filterByDate(i, startDate, endDate); // We call our filter function
            }
            dt_adv_filter_table.dataTable().fnDraw();
        } else {
            dt_adv_filter_table.DataTable().column(i).search(val, false, true).draw();
        }
    }

    // Advance filter function
    // We pass the column location, the start date, and the end date
    //$.fn.dataTableExt.afnFiltering.length = 0;
    //var filterByDate = function (column, startDate, endDate) {
    //    // Custom filter syntax requires pushing the new filter to the global filter array
    //    $.fn.dataTableExt.afnFiltering.push(function (oSettings, aData, iDataIndex) {
    //        var rowDate = normalizeDate(aData[column]),
    //            start = normalizeDate(startDate),
    //            end = normalizeDate(endDate);

    //        // If our date from the row is between the start and end
    //        if (start <= rowDate && rowDate <= end) {
    //            return true;
    //        } else if (rowDate >= start && end === '' && start !== '') {
    //            return true;
    //        } else if (rowDate <= end && start === '' && end !== '') {
    //            return true;
    //        } else {
    //            return false;
    //        }
    //    });
    //};

    // converts date strings to a Date object, then normalized into a YYYYMMMDD format (ex: 20131220). Makes comparing dates easier. ex: 20131220 > 20121220
    var normalizeDate = function (dateString) {
        var date = new Date(dateString);
        var normalized =
            date.getFullYear() + '' + ('0' + (date.getMonth() + 1)).slice(-2) + '' + ('0' + date.getDate()).slice(-2);
        return normalized;
    };
   


    // Column Search
    // --------------------------------------------------------------------

    if (dt_filter_table.length) {
        // Setup - add a text input to each footer cell
        $('.dt-column-search thead tr').clone(true).appendTo('.dt-column-search thead');
        $('.dt-column-search thead tr:eq(1) th').each(function (i) {
            var title = $(this).text();
            $(this).html('<input type="text" class="form-control" placeholder="Search ' + title + '" />');

            $('input', this).on('keyup change', function () {
                if (dt_filter.column(i).search() !== this.value) {
                    dt_filter.column(i).search(this.value).draw();
                }
            });
        });

        var dt_filter = dt_filter_table.DataTable({
            "processing": true,
            "serverSide": true,
            "filter": true,
            "ajax": {
                "url": "/allCompalintsVewi",
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
                { "data": "titleComplaint", "name": "TitleComplaint",   },
                { "data": "descComplaint", "name": "DescComplaint", "autowidth": true },
                { "data": "compDate", "name": "CompDate", "autowidth": true },
                { "data": "propBeneficiarie", "name": "PropBeneficiarie", "autowidth": true },
                //{ "data": "compDate", "name": "CompDate", "autowidth": true },
                //{ "data": "titleComplaint", "name": "TitleComplaint", "autowidth": true },
            ],
            orderCellsTop: true,
            dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>><"table-responsive"t><"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>'
        });
    }

  

    // on key up from input field
    $('input.dt-input').on('keyup', function () {
        filterColumn($(this).attr('data-column'), $(this).val());
    });

   
    // Filter form control to default size
    // ? setTimeout used for multilingual table initialization
    setTimeout(() => {
        $('.dataTables_filter .form-control').removeClass('form-control-sm');
        $('.dataTables_length .form-select').removeClass('form-select-sm');
    }, 200);
});
