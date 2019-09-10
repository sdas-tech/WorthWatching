console.log("in the content script");
window.addEventListener('mouseup', wordSelected);

function wordSelected() {
    console.log("wordselected event");

    let selectedText = window.getSelection().toString().trim();
    console.log(selectedText);
    if (selectedText.length > 0) {
        let message = {
            text: selectedText
        };
        chrome.runtime.sendMessage(message);
    }
}