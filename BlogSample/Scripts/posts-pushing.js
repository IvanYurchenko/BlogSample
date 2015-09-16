$(document).ready(function () {
	var soundObject = null;
	var blogHub = $.connection.blogHub;

	function playSound() {
		if (soundObject != null) {
			document.body.removeChild(soundObject);
			soundObject.removed = true;
			soundObject = null;
		}
		soundObject = document.createElement("audio");
		soundObject.setAttribute("src", "/Sounds/message.wav");
		soundObject.setAttribute("hidden", true);
		soundObject.setAttribute("autostart", true);
		document.body.appendChild(soundObject);
		soundObject.play();
	}

	blogHub.client.refreshPosts = function () {
		refreshPostsList();

		playSound();
	};

	$.connection.hub.start().done(function () {
		blogHub.server.register();
	});
});