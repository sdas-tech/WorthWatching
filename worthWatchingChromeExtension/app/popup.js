console.log("in the popup.js");
let bgpage = chrome.extension.getBackgroundPage();
let word = bgpage.word.trim();
console.log(document.getElementById('pagetitle'));

let url = `https://worthwatchingapi.azurewebsites.net/api/Movies/${word}`;

document.getElementById('showtitle').innerHTML = "?";
document.getElementById('imdbRating').innerHTML = "?";
document.getElementById('rtRating').innerHTML = "?";
document.getElementById('metacriticRating').innerHTML = "?";

fetch(url)
.then((response) => response.json())
.then(function(data) {
    document.getElementById('showtitle').innerHTML = data.title;
    document.getElementById('imdbRating').innerHTML = data.imdbRating;
    document.getElementById('rtRating').innerHTML = data.rtRating;
    document.getElementById('metacriticRating').innerHTML = data.metacriticRating;
})
.catch(function(error) {
    console.log("got an error");
    console.error(error);
});