//constants
var gridimgpath = '/themes/images';
var ID_SELECTOR = "#";

//setup page defaults for jgrid
$.jgrid.no_legacy_api = true;
$.jgrid.useJSON = true;
//setup for tabs, buttons, accordian
$(function () {
	$("#tabs").tabs({ collapsible: true });
	$('.button').button();
	$("#accordion").accordion();
});

$(document).ready(function () {
	// call function in button click event
	$("#Reset").click(function () {
		//Iterate over all the text fields
		$('input[type=text]').each(function () {
			this.value = "";
		});
		$('select').each(function () {
			this.selectedIndex = 0;
		});
		//remove grid selections
		$("#GridRoleList").resetSelection();
		$("#ExactMatch").attr('checked', 'checked');
	});

	//jgrowl setup
	$.jGrowl.defaults.sticky = true;
});

function AttachAutoComplete(gridName, autoCompleteName,columnName) {
	var ids = $(ID_SELECTOR + gridName).getDataIDs();
	var _array = new Array();
	for (var i = 0; i < ids.length; i++) {
		_array[i] = $(ID_SELECTOR + gridName).getCell(i, columnName);
	};

	$(ID_SELECTOR + autoCompleteName).autocomplete({
		source: _array,
		//Minimum number of characters a user has to type before the autocompleter activates
		minChars: 2,
		//Fill the input while still selecting a value
		autoFill: true,
		//Only suggested values are valid
		mustMatch: true

	});
}

	$(document).ready(function () {
		$("#GridRoleList").jqGrid({
			url: "DataService.svc/GetRoles",
			datatype: 'json',
			mtype: 'GET',
			gridComplete: function () { AttachAutoComplete("GridRoleList", "Role", "Name"); },
			colNames: ['Role Names'],
			colModel: [
			{ name: 'Name', index: 'Name' }
		],
			imgpath: gridimgpath,
			viewrecords: true,
			sortorder: "desc",
			loadtext: "Loading...",
			loadui: "block",
			sortable: true,
			multiselect: true,
			width: 300,
			hidegrid: false,
			autowidth: false,
			loadonce: true,
			jsonReader: {
				root: "d.rows",
				page: "d.page",
				total: "d.total",
				records: "d.records",
				repeatitems: true,
				cell: "cell",
				id: "id",
				userdata: "userdata",
				subgrid: { root: "d.rows", repeatitems: true, cell: "cell" }
			},
			loadError: function (xhr, st, err) {
				$.jGrowl("Type: " + st + "; Response: " + xhr.status + " " + xhr.statusText, { header: 'Service Error' });
			}

		});

	});


