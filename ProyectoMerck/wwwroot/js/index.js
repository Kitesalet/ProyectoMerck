


  /*  const submitButton = document.getElementById('FertSubmitButton');*/



    //var form = document.getElementById('CalculateFertilityForm');
    //form.addEventListener('submit', (event) => {
    //    event.preventDefault();

    //    AgeSubmitHandler();
    //})



console.log('Hola!')
// Function to filter clinics based on selected Provincia
document.getElementById('provincelocationDropdown').addEventListener('change', function () {
    var selectedProvincia = parseInt(this.value) + 1;

    document.querySelectorAll('.clinic-icon, .clinic-text').forEach(function (element) {
        element.classList.add('d-none');
    });

    document.querySelectorAll('.clinic-icon[data-provincia="' + selectedProvincia + '"]').forEach(function (icon) {
        icon.classList.remove('d-none');
    });

    document.querySelectorAll('.clinic-text[data-provincia="' + selectedProvincia + '"]').forEach(function (textElement) {
        textElement.classList.remove('d-none');
    });
});

document.querySelectorAll('.clinic-icon').forEach(function (icon) {
    icon.classList.add('nonselected-clinic');

    icon.addEventListener('click', function () {
        document.querySelectorAll('.clinic-icon').forEach(function (otherIcon) {
            otherIcon.classList.remove('selected-clinic');
            otherIcon.classList.add('nonselected-clinic');
        });

        this.classList.remove('nonselected-clinic');
        this.classList.add('selected-clinic');
        updateHiddenField();
    });
});

// Function to update hidden field based on selected clinic
function updateHiddenField() {
    var selectedProvincia = parseInt(document.querySelector('.selected-clinic').id) + 1;
    document.getElementById('SelectedLocationIndex').value = selectedProvincia || '';
}

