$(document).ready(function () {
    // call function in button click event
    $("#Search").click(function () {
        getData(SEARCH_GRID);
        //cancel the event after load 
        return false;
    });

});

function BuildParameters() {
    var params = new Object();
    var Searchparams = new Object();
    var Gridparams = new Object();

    Gridparams.Page = $("#" + SEARCH_GRID).getGridParam('page');
    Gridparams.PageSize = $("#" + SEARCH_GRID).getGridParam('rownuum');
    Gridparams.SortIndex = $("#" + SEARCH_GRID).getGridParam('sortname');
    Gridparams.SortDirection = $("#" + SEARCH_GRID).getGridParam('sortorder');
    params.exportInterface = $("#ExportInterface").val();
    Searchparams.Environment = $("#Environment").val();
    Searchparams.ExactMatch = $("#ExactMatch").val();
    Searchparams.RoleList = $("#GridRoleList").getGridParam('selarrrow');
    Searchparams.SingleRole = $("#Role").val();
    Searchparams.matchedRoles = $("#MatchedRoles").val();
    Searchparams.UserIdType = $("#UserIdType").val();
    Searchparams.UserId = $("#UserId").val();
    params.selectedSearchParameters = Searchparams;
    params.gridParameters = Gridparams;
    return params;
}

function BuildExportParameters() {
    var params = new Object();

    params.exportInterface = $("#ExportInterface").val();
    params.Environment = $("#Environment").val();
    params.ExactMatch = $("#ExactMatch").val();
    params.RoleList = $("#GridRoleList").getGridParam('selarrrow');
    params.SingleRole = $("#Role").val();
    params.matchedRoles = $("#MatchedRoles").val();
    params.UserIdType = $("#UserIdType").val();
    params.UserId = $("#UserId").val();
    return params;
}

function getData(GridName) {
    //exit function if parameters have not been selected.
    if (!IsValid()) {
        $.jGrowl("Please enter valid paramaters.", { header: 'Validation Error', sticky: false });
        return;
    }
    // show the grid
    //var _grid = $("#" + GridName);
    //_grid.show();
    $("#accordion").accordion("activate", 1);
    ShowWaiting(GridName);
    var params = new Object();
    params = BuildParameters();


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "DataService.svc/SearchResults",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (data, textStatus) {
            if (textStatus == "success") {
                if (data.d.ErrorMessage.length > 0) {
                    $.jGrowl(data.d.ErrorMessage, { header: 'Validation Error', sticky: false });
                }
                else {                 
                    var _grid = $("#" + GridName)[0];
                    _grid.addJSONData(data.d.JqGrid);
                }
            }
        },
        error: function (data, textStatus) {
            $.jGrowl("Type: Ajax" + "; Response: " + data + " " + textStatus, { header: 'Service Error' });
        }
    });
    Cleanup(GridName);
}

function ShowWaiting(GridName) {
   $("#load_" + GridName).show();
    $("#lui_" + GridName).show();
 
}

function Cleanup(GridName) {
    $("#load_" + GridName).hide();
    $("#lui_" + GridName).hide();
//        var recs = parseInt($("#" + GridName).getGridParam("records"), 10);
//        if (recs == 0) {
//            $("#SearchResultsContainer").hide();
//        }
//        else {
//            $("#SearchResultsContainer").show();
//        }
}

function IsValid(){
    var _RoleList = $("#GridRoleList").getGridParam('selarrrow');
    var _SingleRole = $("#Role").val;
    var _UserId = $("#UserId").val;
    if (_UserId.length == 1 && _SingleRole.length == 1 && _RoleList.length == 0) {
        return false;
    }
    return true;
}

var SEARCH_GRID = "GridSearchResults";

$(document).ready(function () {
    $("#" + SEARCH_GRID).jqGrid({
        datatype: 'json',
        gridComplete: function () {  Cleanup(SEARCH_GRID); },
        colNames: ['USEC', 'hcsiskey-password', 'First Name', 'Last Name', 'Scope', 'Role'],
        colModel: [
            { name: 'USEC', index: 'USEC', sorttype: 'text', sortable: true },
            { name: 'hcsiskey-password', index: 'DatabaseUserName', sorttype: 'text', sortable: true },
            { name: 'First Name', index: 'FirstName', sorttype: 'text', sortable: true },
            { name: 'Last Name', index: 'LastName', sorttype: 'text', sortable: true },
            { name: 'Scope', index: 'Scope', sorttype: 'text', sortable: true },
            { name: 'Role', index: 'Role', sorttype: 'text', sortable: true }
        ],
        imgpath: gridimgpath,
        sortname: 'USEC',
        sortorder: "asc",
        viewrecords: true,
        caption: "Managed User Search Results",
        loadtext: "Loading...",
        hidegrid: false,
        loadui: "block",
        pager: '#pagerdt',
        sortable: true,
        //height: "100%",
        //width: 650,
        autowidth: true,
        gridView: true,
        //viewsortcols: false,
        pgtext: "",
        ignoreCase: true,
        loadonce: true
    });

    // Set navigator with search enabled.
    $("#pagerdt").find("#first, #prev, input.selbox, #sp_1, #sp_2, #next, #last").hide();

    $("#" + SEARCH_GRID).navGrid('#pagerdt', { search: false, edit: false, add: false, del: false, refresh: false },
                        {}, // default settings for edit
                        {}, // default settings for add
                        {}, // delete
                        {closeOnEscape: true, multipleSearch: false, closeAfterSearch: true }, // search options
                        {}
            );
    $("#" + SEARCH_GRID).jqGrid('navGrid', "#pagerdt").jqGrid('navButtonAdd', "#pagerdt", { title: "Export to Excel", caption: "", buttonicon: "ui-icon-calculator", position: "last",
        onClickButton: function () {
            //jQuery("#" + SEARCH_GRID).excelExport({ url: 'exportGrid.aspx' });

            //$.download('FileTransferService.svc/DownloadFile', BuildParameters());
            $.download('exportgrid.aspx', BuildExportParameters());

        }
    });

    $("#add_" + SEARCH_GRID).hide();
    $("#edit_" + SEARCH_GRID).hide();
    $("#del_" + SEARCH_GRID).hide();


});
