$(".viewDialog").live("click", function (e) {
    var url = $(this).attr('href');
    $("#modalView").dialog({
        title: 'VWEB dummy',
        autoOpen: false,
        resizable: false,
        height: 350,
        width: 900,
        show: { effect: 'ease in', direction: "down" },
        modal: true,
        draggable: false,
        open: function (event, ui) {
            $(this).load(url);

        },

        buttons: {
            "Close": function () {
                $(this).dialog("close");

            }
        },
        close: function (event, ui) {
            $(this).dialog('close');
        }
    });

    $("#modalView").dialog('open');
    return false;
});

$(".editDialog").live("click", function (e) {
    var url = $(this).attr('href');
    $("#modalEdit").dialog({
        title: 'VWEB dummy',
        autoOpen: false,
        resizable: false,
        height: 550,
        width: 900,
        show: { effect: 'ease in', direction: "down" },
        modal: true,
        draggable: false,
        open: function (event, ui) {
            $(this).load(url);

        },
        buttons: {
            "Close": function () {
                $(this).dialog("close");

            }
        },
        close: function (event, ui) {
            $(this).dialog('close');
        }
    });

    $("#modalEdit").dialog('open');
    return false;
});

$(".deleteDialog").live("click", function (e) {
    var url = $(this).attr('href');
    $("#modalDelete").dialog({
        title: 'VWEB dummy',
        autoOpen: false,
        resizable: false,
        height: 350,
        width: 900,
        show: { effect: 'ease in', direction: "down" },
        modal: true,
        draggable: false,
        open: function (event, ui) {
            $(this).load(url);

        },
        buttons: {
            "Close": function () {
                $(this).dialog("close");

            }
        },
        close: function (event, ui) {
            $(this).dialog('close');
        }
    });

    $("#modalDelete").dialog('open');
    return false;
});