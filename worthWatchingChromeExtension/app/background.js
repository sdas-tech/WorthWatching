console.log('background running');

chrome.runtime.onMessage.addListener(receiver);

window.word = "replace me";

function receiver(request, sender, sendResponse) {
    console.log(request);
    word = request.text;
}