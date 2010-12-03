<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC “-//W3C//DTD XHTML 1.0 Strict//EN” “http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd”>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>USEC Managed User Lookup</title>
	<link rel="stylesheet" type="text/css" media="screen" href="themes/jquery-ui-1.8.4.custom.css" />
	<link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
	<link rel="stylesheet" type="text/css" media="screen" href="themes/jquery.jgrowl.css" />
	<script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
	<script src="js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
	<script src="js/grid.locale-en.js" type="text/javascript"></script>
	<script src="js/jquery.jqGrid.min.js" type="text/javascript"></script>
	<script src="js/json2.js" type="text/javascript"></script>
	<script src="js/jquery.jgrowl_minimized.js" type="text/javascript"></script>
	<script src="js/jquery.download.js" type="text/javascript"></script>
	<script src="js/Search/SearchPage.js" type="text/javascript"></script>
	<script src="js/Search/SearchResults.js" type="text/javascript"></script>

</head>

<body>
	<form id="form1" action="Default.aspx">
	<h1 class="pagetitle ui-widget-header">HCSIS USEC Managed User Lookup</h1>
	<div id="accordion">
	<h4><a href="#">Parameters</a></h4>
		<div>
	<h3 class="pagedesc ui-state-highlight">Enter the search criteria and then click the search button for results.</h3>
	<input type="hidden" id="ExportInterface" value="TestUser" />
	<div class="formItem">
		<label>Environment</label>
		 <select id="Environment">
						<option value="<%= ManagedUserLookup.Library.Environment.Development%>"><%= ManagedUserLookup.Library.Environment.Development%></option>
						<option value="<%= ManagedUserLookup.Library.Environment.Integration%>"><%= ManagedUserLookup.Library.Environment.Integration%></option>
						<option value="<%= ManagedUserLookup.Library.Environment.SystemAcceptance%>"><%= ManagedUserLookup.Library.Environment.SystemAcceptance%></option>
						<option value="<%= ManagedUserLookup.Library.Environment.Load%>"><%= ManagedUserLookup.Library.Environment.Load%></option>
						<option value="<%= ManagedUserLookup.Library.Environment.TestForProduction%>"><%= ManagedUserLookup.Library.Environment.TestForProduction%></option>
					</select>
	</div>
	<div class="formItem">
		<label>Only show results that match criteria</label>
						<select id="ExactMatch">
						<option value="Yes">Yes</option>
						<option value="No">No</option>
					</select>
	</div>
	<div id="tabs">
		<ul>
			<li><a href="#tab1">Role Search</a></li>
			<li><a href="#tab2">User Search</a></li>
		</ul>
			<div id="tab1">
				<div><table id="GridRoleList"></table>
				</div>
				<div class="formItem">
					<label>Role</label>
					<input id="Role" size="35" />
				</div>
				<div class="formItem">
					<label>Combined Roles to Match</label> 
					<select id="MatchedRoles">
						<option value="All">All</option>
						<option value="1">1</option>
						<option value="2">2</option>
						<option value="3">3</option>
						<option value="4">4</option>
						<option value="5">5</option>
					</select>
				</div>
			</div>
			<div id="tab2">
				<div class="formItem" >
					<label>User ID Type</label> 
					<select id="UserIdType">
						<option value="USEC">USEC</option>
						<option value="HCSIS Key">HCSIS Key</option>                     
					</select>
				</div>
				<div class="formItem">
					<label>User ID</label> 
					<input id="UserId" /> 
				</div>
			</div>
	  </div>

	  <div>
	  <button id="Reset" class="button">Reset</button><button id="Search" class="button">Search</button>
	  </div>
	  </div>
	  <h4><a href="#">Results</a></h4>
		<div>
	  <div id="SearchResultsContainer"><table id="GridSearchResults"></table>
			<div id="pagerdt" ></div>
	  </div>
		</div>
	</div>
	</form>
</body>
</html>
