
jQuery(document).ready(function () {
    $("#getweekday").click(function () {
        var firstDay = $('#firstweekday')[0].value;
        var secondDay = $('#secondweekday')[0].value;
        getWeekDays(firstDay, secondDay);
    });
    $("#getbusday").click(function () {
        var firstDay = $('#firstbusday')[0].value;
        var secondDay = $('#secondbusday')[0].value;
        var holidayList = $.trim($("#holidayList").val()).split("\n");
        getBusinessDays(firstDay, secondDay, holidayList);
    });
});
function getWeekDays(firstDay, secondDay) {
    var data = { FirstDate: firstDay, SecondDate: secondDay};
    $.ajax({
        url: window.location.origin + "/CalculateDays/GetWeekDays",
        type: 'POST',
        data: data,
        error: function (errorThrown) {
            $("#weekdaysReturn").html(errorThrown.responseText);
        },
        success: function (result) {
            $("#weekdaysReturn").html(result);
        }
    });

}
function getBusinessDays(firstDay, secondDay,holidays) {
    var data = { FirstDate: firstDay, SecondDate: secondDay, PublicHolidays: holidays };
    $.ajax({
        url: window.location.origin + "/CalculateDays/GetBusinessDays",
        type: 'POST',
        data: data,
        error: function (errorThrown) {
            $("#businessdaysReturn").html(errorThrown.responseText);
        },
        success: function (result) {
            $("#businessdaysReturn").html(result);
        }
    });

}
$(function () {
    $("#datepickerweekdayfirst").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());
    $("#datepickerweekdaysec").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());
    
    $("#datepickerbusdayfirst").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());
    $("#datepickerbusdaysec").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());
});