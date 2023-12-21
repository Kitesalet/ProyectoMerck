// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var clinicLink = document.getElementById('clinicButton');
var loadingSpinner = document.getElementById('loadingSpinner');

clinicLink.addEventListener('click', function () {
    showLoadingSpinner();
})

function showLoadingSpinner() {
    const loadingSpinner = document.getElementById('loadingSpinner');
    loadingSpinner.style.display = 'block';

}

// Hide the loading spinner and show the main content
function hideLoadingSpinner() {
    const loadingSpinner = document.getElementById('loadingSpinner');
    const mainContent = document.getElementById('mainContent');

    console.log(mainContent);

    loadingSpinner.style.display = 'none';
    mainContent.style.display = 'block';
}

