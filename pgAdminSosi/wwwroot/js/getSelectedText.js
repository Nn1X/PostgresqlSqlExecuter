function get_selected_text() {
	if (window.getSelection()) {
		var select = window.getSelection();
		return select.toString();
	}
	return "";
}

document.addEventListener('keydown', (e) => {
    e = e || window.event;
    if (e.keyCode == 116) {
        e.preventDefault();
    }
});