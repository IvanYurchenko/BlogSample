function refreshPostsList() {
	var searchQuery = $("#textbox-search").val();

	if (searchQuery.length > 0) {
		searchQuery = "?searchQuery=" + searchQuery;
	}

	$("#posts-container").load("/Home/Posts/" + searchQuery, function () {
		$("#button-update").click(function () {
			refreshPostsList();
		});
	});
}

$(document).ready(function () {
	refreshPostsList();
})