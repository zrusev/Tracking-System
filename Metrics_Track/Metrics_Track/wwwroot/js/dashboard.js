$(function () {
    //Select process node
    $('.btn-default').on('click', function () {
        var selection = $(this).find('input').attr('id');
        var selectionName = $(this).text().trim();
        var division = $(this).parent().attr("id");

        switch (division) {
            case "Lob":
                $('input[name=LobSelection]').val(selection);
                $('input[name=LobName]').val(selectionName);
                break;
            case "Activity":
                $('input[name=ActivitySelection]').val(selection);
                $('input[name=ActivityName]').val(selectionName);
                break;
            case "Status":
                $('input[name=StatusSelection]').val(selection);
                $('input[name=StatusName]').val(selectionName);
                break;
        }
    });

    //Select country node
    $(".list-group-item").on("click", function () {
        var division = $(this).data("parent");
        var isAriaExpanded = $(this).attr("aria-expanded") === 'true' ? true : false;
        expandCollapseAria($(this), isAriaExpanded, division);
    });

    //Update status
    $("#useractivity").on('change', function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
       
        var token = $('input[name="__RequestVerificationToken"]', $("#submittranform")).val();
        var jsonObject = {
            Type : $(this).val(),
            Comment: $("#comment1").val()
        };

        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/dashboard/UpdateStatus',
            data: {
                "__RequestVerificationToken": token,
                model: jsonObject
            },
            success: function (response) {
                document.getElementById("currentstatus").innerHTML = response.status;
            },
            error: function (response) {
                alert('Internal error. Please contact support.');
            }
        });
        return false;
    });

    //Submit form
    $("#submittranform").on('submit', function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        $(this).find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();
        $(this).data("validator").settings.ignore = "";

        var token = $('input[name="__RequestVerificationToken"]', $(this)).val();
        var jsonObject = {
            IdCountry : $('input[name=CountrySelection]').val(),
            IdProcess : $('input[name=ProcessSelection]').val(),
            IdActivity : $('input[name=ActivitySelection]').val(),
            IdLob : $('input[name=LobSelection]').val(),
            IdDivision : $('input[name=ProcessSelection]').val(),
            IdTowerCategory : $('input[name=ProcessSelection]').val(),
            IdTower : $('input[name=ProcessSelection]').val(),
            ReceivedDate: moment($("#Transaction_ReceivedDate").val()).isValid() ? moment($("#Transaction_ReceivedDate").val()).format("YYYY-MM-DD HH:mm:ss") : null,
            StartDate: null,
            IdStatus : $('input[name=StatusSelection]').val(),
            Comment : $("#comment1").val(),
            IdNumber : $("#policynumber1").val(),
            Premium: $("#amount1").val(),
            CurrencyCode: $("#currCode1").val(),
            IsPriority: $("#priorityCheck").prop('checked'),
            InceptionDate: moment($("#Transaction_InceptionDate").val()).isValid() ? moment($("#Transaction_InceptionDate").val()).format("YYYY-MM-DD HH:mm:ss") : null,
            DateReceivedInAig: moment($("#Transaction_DateReceivedInAig").val()).isValid() ? moment($("#Transaction_DateReceivedInAig").val()).format("YYYY-MM-DD HH:mm:ss") : null
        };

        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/dashboard/SubmitTransaction',
                data: {
                    "__RequestVerificationToken" : token,
                    model: jsonObject
                },
                success: function (data) {
                    if (data.success) {
                        //Add to pending transactions
                        var process = $('input[name=ProcessName]').val();
                        var processIdentifier = "#process-" + $('input[name=ProcessSelection]').val();
                        var lob = $('input[name=LobName]').val();
                        var premiumAmount = data.prem == null ? "" : data.prem;
                        var receivedDate = moment($("#Transaction_ReceivedDate").val()).format("YYYY-MM-DD HH:mm:ss");
                        var id = data.newId;
                        var status = $('input[name=StatusName]').val();

                        var previousTable = $("#previousTransactionTable");
                        $("#previousTransactionTable > tbody").html("");
                        var newRow = "<tr id=previous-" + id + "><td>" + process + "</td><td>" + lob + "</td><td>" + premiumAmount + "</td><td>" + receivedDate + "</td><td><button type=\"button\" class=\"btn btn-info btn-xs\" onclick=\"returnTransaction(" + id + ")\">" + id + "</button></td><td>" + status + "</td></tr>";
                        previousTable.append(newRow);

                        if (data.pending) {
                            var pendingTable = $("#pendingTransactionTable");
                            var addIdToRow = newRow.replace("<tr id=previous-" + id + ">", "<tr id=pending-" + id + ">")
                            pendingTable.append(addIdToRow);
                        }

                        //Last transaction
                        $("#previousProcessId").val($('input[name=ProcessSelection]').val());
                        $("#previousLobId").val($('input[name=LobSelection]').val());
                        $("#previousPremium").val(premiumAmount);
                        $("#previousReceivedDate").val(receivedDate); 
                        $("#previousDocId").val(id);
                        $("#previousStatusId").val($('input[name=StatusSelection]').val());

                        //Clear form
                        var sectionBoxCheck = $("#sectionCheck").prop('checked');
                        var receivedBoxCheck = $("#receivedCheck").prop('checked');
                        var priorityBoxCheck = $("#priorityCheck").prop('checked');
                        resetForm($("#submittranform"), processIdentifier, sectionBoxCheck, receivedBoxCheck, priorityBoxCheck);

                        //Set new startDate
                        $("#Transaction_StartDate").val(moment(new Date(data.startDate)).format("YYYY-MM-DD HH:mm:ss"));
                    }
                    else {
                        $.each(data.errors, function (ind, err) {
                            alert(err);
                        });
                    }
                },
                error: function (response) {
                    alert('Internal error. Please contact support.');
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

//Set values
function expandCollapseAria(currentElement, isAriaExpanded, division) {
    if (isAriaExpanded) {
        if (division === "#country") {
            $('input[name=CountrySelection]').val("");

            var processIdentifier = "#process-" + $('input[name=ProcessSelection]').val();
            var btns = currentElement.parent().next().find(".btn-group-vertical label");
            btns.each(function (index, item) {
                item.classList.remove('active');
            });
            $(processIdentifier).attr('aria-expanded', false);
            $(processIdentifier).prev().children().attr('aria-expanded', false);
            $(processIdentifier).removeClass('in');
        }
        $('input[name=ProcessSelection]').val("");
        $('input[name=ProcessName]').val("");
        $('input[name=ActivitySelection]').val("");
        $('input[name=ActivityName]').val("");
        $('input[name=LobSelection]').val("");
        $('input[name=LobName]').val("");
        $('input[name=StatusSelection]').val("");
        $('input[name=StatusName]').val("");
        //console.log("hide");
    } else {
        var btns = currentElement.parent().next().find(".btn-group-vertical label");
        btns.each(function (index, item) {
            item.classList.remove('active');
        });

        $('input[name=ActivitySelection]').val("");
        $('input[name=ActivityName]').val("");
        $('input[name=LobSelection]').val("");
        $('input[name=LobName]').val("");
        $('input[name=StatusSelection]').val("");
        $('input[name=StatusName]').val("");

        var selection = currentElement.data("id");
        var selectionName = currentElement.text().trim();

        if (division === "#country") {
            $("#Transaction_IdCountry").val(selection);
        } else {
            $("#Transaction_IdProcess").val(selection);
            $('input[name=ProcessName]').val(selectionName);
        }
        //console.log("show");
    }
}

function returnTransaction(transactionId) {
    $.ajax({
        type: "Get",
        url: '/dashboard/returntransaction',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: { transactionId: transactionId },
        success: function (response) {
            if (response.success) {
                closeOpened(response.idCountry);
                openClosed(response.idCountry, response.idProcess);

                populateData(response);

                $("#previous-" + transactionId).remove();

                $("#pending-" + transactionId).remove();
            } else {
                alert(response.errors);
            }
        },
        error: function (ex) {
            alert('Internal error. Please contact support.');
        }
    });
    return false;
}

//Set values from response
function populateData(response) {
    $("#Transaction_IdCountry").val(response.idCountry);
    $("#Transaction_IdProcess").val(response.idProcess);
    $('input[name=ProcessName]').val(response.process);
    $("#Transaction_IdActivity").val(response.idActivity);
    $('input[name=ActivityName]').val(response.activity);
    $("#Transaction_IdLob").val(response.idLob);
    $('input[name=LobName]').val(response.lob);
    $("#Transaction_IdStatus").val(response.idStatus);
    $('input[name=StatusName]').val(response.status);
    //IdDivision, IdTowerCategory, IdTower
    $("#Transaction_ReceivedDate").val(moment(new Date(response.receivedDate)).format("YYYY-MM-DD HH:mm:ss"));
    //StartDate, CompleteDate
    $("#comment1").val(response.comment);
    $("#policynumber1").val(response.idNumber);
    $("#amount1").val(response.premium);
    $("#currCode1").val(response.currencyCode);
    if (response.priority == 1) {
        $("#priorityCheck").prop('checked', true);
    } else {
        $("#priorityCheck").prop('checked', false);
    }
    if (response.inceptionDate !== null) {
        $("#Transaction_InceptionDate").val(moment(new Date(response.inceptionDate)).format("YYYY-MM-DD HH:mm:ss"));
    } else {
        $("#Transaction_InceptionDate").val('');
    }
    if (response.dateReceivedInAig !== null) {
        $("#Transaction_DateReceivedInAig").val(moment(new Date(response.dateReceivedInAig)).format("YYYY-MM-DD HH:mm:ss"));
    } else {
        $("#Transaction_DateReceivedInAig").val('');
    }

    //Mark Lob, Activity, Status
    var processIdentifier = "#process-" + response.idProcess;
    $(processIdentifier).find("#Lob").children().find("input").filter("#" + response.idLob).parent().addClass('active');
    $(processIdentifier).find("#Activity").children().find("input").filter("#" + response.idActivity).parent().addClass('active');
    $(processIdentifier).find("#Status").children().find("input").filter("#" + response.idStatus).parent().addClass('active');
}

//Close open process and country section
function closeOpened(idCountry) {
    var processIdentifier = "#process-" + $('input[name=ProcessSelection]').val();
    expandCollapseAria($(processIdentifier), true, '');
    $(processIdentifier).attr('aria-expanded', false);
    $(processIdentifier).prev().children().attr('aria-expanded', false);
    $(processIdentifier).removeClass('in');

    var isCountryOpened = $('input[name=CountrySelection]').val();
    if (parseInt(isCountryOpened) !== idCountry && isCountryOpened !== "") {
        var countryIdentifier = "#country-" + isCountryOpened;
        $(countryIdentifier).attr('aria-expanded', false);
        $(countryIdentifier).prev().children().attr('aria-expanded', false);
        $(countryIdentifier).removeClass('in');
        $("#Transaction_IdCountry").val('');
    }
}

//Open closed sections
function openClosed(idCountry, idProcess) {
    var isCountryOpened = $('input[name=CountrySelection]').val();
    if (isCountryOpened === "") {
        var countryIdentifier = "#country-" + idCountry;
        $(countryIdentifier).attr('aria-expanded', true);
        $(countryIdentifier).prev().children().attr('aria-expanded', true);
        $(countryIdentifier).addClass('in');
    }

    var processIdentifier = "#process-" + idProcess;
    $(processIdentifier).attr('aria-expanded', true);
    $(processIdentifier).prev().children().attr('aria-expanded', true);
    $(processIdentifier).addClass('in');
}

//Clear values
function resetForm($form, processIdentifier, sectionBoxCheck, receivedBoxCheck, priorityBoxCheck) {
    var sBox = sectionBoxCheck === true ? "#sectionCheck" : '';
    var rBox = receivedBoxCheck === true ? "#receivedCheck" : '';
    var pBox = priorityBoxCheck === true ? "#priorityCheck" : '';
    var rValue = receivedBoxCheck === true ? "#Transaction_ReceivedDate" : '';

    if (sectionBoxCheck == true) {
        //do nothing
    } else {
        $form.find('input:text, input:password, input:file, select, textarea').not(rValue).not("#Transaction_StartDate").not("#Transaction_IdCountry").val('');
        expandCollapseAria($(processIdentifier), true, '');
        $(processIdentifier).attr('aria-expanded', false);
        $(processIdentifier).prev().children().attr('aria-expanded', false);
        $(processIdentifier).removeClass('in');
    }

    $form.find('input:radio, input:checkbox').filter(sBox | rBox | pBox).prop('checked', true);
}