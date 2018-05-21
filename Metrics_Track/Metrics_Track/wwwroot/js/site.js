$(function () {
    $('#btnSave').click(function () {
        UpdateStatus()
    });

    $('.btn-default').on('click', function () {
        var division = $(this).parent().attr("id");
        var selection = $(this).find('input').attr('id');
        var selectionName = $(this).text().trim();

        if (division == "Lob") {
            $('input[name=LobSelection]').val(selection);
            $('input[name=LobName]').val(selectionName);
        } else if (division == "Activity") {
            $('input[name=ActivitySelection]').val(selection);
            $('input[name=ActivityName]').val(selectionName);
        } else if (division == "Status") {
            $('input[name=StatusSelection]').val(selection);
            $('input[name=StatusName]').val(selectionName);
        }
    });

    $(".list-group-item").on("click", function () {
        var division = $(this).data("parent");

        if ($(this).attr("aria-expanded") === 'true') {
            if (division == "#country") {
                $('input[name=CountrySelection]').val("");
            }

            $('input[name=ProcessSelection]').val("");
            $('input[name=ProcessName]').val("");
            //console.log("hide");
        } else {
            var btns = $(this).parent().next().find(".btn-group-vertical label");
            btns.each(function (index, item) {
                item.classList.remove('active');
            });

            var selection = $(this).data("id");
            var selectionName = $(this).text().trim();

            if (division == "#country") {
                $('input[name=CountrySelection]').val(selection);
            } else {
                $('input[name=ProcessSelection]').val(selection);
                $('input[name=ProcessName]').val(selectionName);
            }

            $('input[name=ActivitySelection]').val("");
            $('input[name=ActivityName]').val("");
            $('input[name=LobSelection]').val("");
            $('input[name=LobName]').val("");
            $('input[name=StatusSelection]').val("");
            $('input[name=StatusName]').val("");
            //console.log("show");
        }
    });

    $("#useractivity").change(function () {
        var type = $(this).val();
        var comment = $("#comment1").val();
        UpdateStatus(type, comment);
    });

    $("#submittranform").submit(function (e) {
        e.preventDefault();
        $(this).find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();
        $(this).data("validator").settings.ignore = "";
        var token = $('input[name="__RequestVerificationToken"]', $(this)).val();
        if ($(this).valid()) {
            $.ajax({
                type: "Post",
                url: '/dashboard/SubmitTransaction',
                dataType: "json",
                data: {
                    __RequestVerificationToken: token,
                    countryId: $('input[name=CountrySelection]').val(),
                    processId: $('input[name=ProcessSelection]').val(),
                    activityId: $('input[name=ActivitySelection]').val(),
                    lobId: $('input[name=LobSelection]').val(),
                    receivedDate: ($("#datetimepicker1").data("DateTimePicker").viewDate()).format("YYYY-MM-DD HH:mm:ss"),
                    startDate: ($("#datetimepicker1").data("DateTimePicker").viewDate()).format("YYYY-MM-DD HH:mm:ss"),
                    statusId: $('input[name=StatusSelection]').val(),
                    comment: $("#comment1").val(),
                    numberId: $("#policynumber1").val(),
                    premium: $("#amount1").val(),
                    inceptionDate: ($("#datetimepicker2").data("DateTimePicker").viewDate()).format("YYYY-MM-DD HH:mm:ss"),
                    dateReceived: ($("#datetimepicker3").data("DateTimePicker").viewDate()).format("YYYY-MM-DD HH:mm:ss")
                },
                success: function (data) {
                    if (data.success) {
                        var process = $('input[name=ProcessName]').val();
                        var lob = $('input[name=LobName]').val();
                        var premiumAmount = data.prem;
                        var receivedDate = ($("#datetimepicker1").data("DateTimePicker").viewDate()).format("YYYY-MM-DD HH:mm:ss");
                        var id = data.newId;
                        var status = $('input[name=StatusName]').val();

                        var table = $("#previousTransactionTable");
                        $("#previousTransactionTable > tbody").html("");
                        table.append("<tr class=active><td>" + process + "</td><td>" + lob + "</td><td>" + premiumAmount + "</td><td>" + receivedDate + "</td><td><button type=\"button\" class=\"btn btn-info btn-xs\"><a class=\"tblbtn\" href=\"#\">" + id + "</a></button></td><td>" + status + "</td></tr>");

                        $("#previousProcessId").val($('input[name=ProcessSelection]').val());
                        $("#previousLobId").val($('input[name=LobSelection]').val());
                        $("#previousPremium").val(premiumAmount);
                        $("#previousReceivedDate").val(receivedDate); 
                        $("#previousDocId").val(id);
                        $("#previousStatusId").val($('input[name=StatusSelection]').val());

                        resetForm($("#submittranform"));                        
                    }
                    else {
                        $.each(data.errors, function (ind, err) {
                            alert(err);
                        });
                    }
                },
                error: function (ex) {
                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
        } else {
            var validator = $(this).validate();
            $.each(validator.errorList, function (key, value) {
                $errorSpan = $("span[data-valmsg-for='" + value.element.id.replace('_', '.') + "']");
                $errorSpan.html("<span style='color:red'>" + value.message + "</span>");
                //$errorSpan.show();
            });
        }
    });
});

function UpdateStatus(activityType, activityComment) {
    var token = $('input[name="__RequestVerificationToken"]', $("#submittranform")).val();
    $.ajax({
        type: "Post",
        url: '/dashboard/UpdateStatus',
        dataType: "json",
        data: {
            __RequestVerificationToken: token,
            type: activityType,
            comment: activityComment
        },
        success: function (response) {
            document.getElementById("currentstatus").innerHTML = response.status;
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
    return false;
}

function LoadData() {
    $("#tblMining tbody tr").remove();
    $.ajax({
        type: "Get",
        url: '@Url.Action("GetMining")',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: { id: 145 },
        success: function (ajaxResponse) {
            var rows = '';
            $.each(ajaxResponse, function (index, ajaxResponse) {
                rows = "<tr>"
                    + "<td>" + ajaxResponse.idMining + "</td>"
                    + "<td>" + ajaxResponse.state + "</td>"
                    + "</tr>";
                $('#tblMining tbody').append(rows);
            })
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
    return false;
}

function resetForm($form) {
    $form.find('input:text, input:password, input:file, select, textarea').val('');
    $form.find('input:radio, input:checkbox')
        .removeAttr('checked').removeAttr('selected');
}

function GetTokens() {
    var countryId = parseInt($('#country .in').attr("id").split("-")[1]);
    var processId = parseInt($('#process' + '-' + countryId + ' .in').attr("id").split("-")[1]);
    alert(countryId + ' ~ ' + processId);
}