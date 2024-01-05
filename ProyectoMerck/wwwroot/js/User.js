var pdfButton = document.getElementById('pdfButton');
var pdfFromDate = document.getElementById('pdfFromDate');
var pdfToDate = document.getElementById('pdfToDate');

var excelButton = document.getElementById('excelButton');
var excelFromDate = document.getElementById('excelFromDate');
var excelToDate = document.getElementById('excelToDate');

var pdfRadio = document.getElementById('pdfRadio');
var csvRadio = document.getElementById('csvRadio');

pdfRadio.checked = true;

pdfFromDate.addEventListener('change', function () {
    if (pdfToDate.value !== '' && this.value !== '' && pdfRadio !== null) {

        pdfButton.classList.remove('d-none');
    } else {
        pdfButton.classList.add('d-none');
    }
});

pdfToDate.addEventListener('change', function () {
    if (pdfFromDate.value != '' && this.value !== '') {
        pdfButton.classList.remove('d-none');
    } else {
        pdfButton.classList.add('d-none');
    }

});

excelFromDate.addEventListener('change', function () {
    if (excelToDate.value !== '' && this.value !== '') {

        excelButton.classList.remove('d-none');
    } else {
        excelButton.classList.add('d-none');
    }
});

excelToDate.addEventListener('change', function () {
    if (excelFromDate.value != '' && this.value !== '') {
        excelButton.classList.remove('d-none');
    } else {
        excelButton.classList.add('d-none');
    }

});