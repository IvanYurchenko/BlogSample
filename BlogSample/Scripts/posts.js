$(document).ready(function() {
	
	function refreshPostsList() {
			var searchQuery = $("#textbox-search").val();

			if (searchQuery.length > 0) {
				searchQuery = "?searchQuery=" + searchQuery;
			}

			$("#posts-container").load('@Url.Action("Posts","Home")' + searchQuery);
	}

	$("#update").bind("onclick", function() {
		refreshPostsList();
	});

})