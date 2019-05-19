// send the page title as a chrome message
filteredTitles = [];
rawTitles = document.querySelectorAll("h1, h2, h3, h4, h5, h6").forEach(t => filteredTitles.push(t.innerText.toLowerCase().trim()));
filteredTitles = filteredTitles.filter(w => w.length > 2 && w.length < 100);
console.log("about to send this list to popup.js:");
console.log(filteredTitles);
chrome.runtime.sendMessage(filteredTitles);
console.log("sent to popup.js");