    function countryHandler(provincias, value) {

    var submitButton = document.getElementById('submitter');
    submitButton.classList.add('d-none');

    var selectedCountry = parseInt(value);

    var allProvincias = provincias;

    var filteredProvincias = allProvincias.filter(function (provincia) {
        return provincia.countryId === selectedCountry;
    })

        if (filteredProvincias.length == 0) {
            Swal.fire({
                icon: "error",
                title: "Ups...",
                text: "No hay clinicas disponibles en el pais seleccionado! Por favor, elija otro pais",
            });
        }

    document.querySelectorAll('.clinic-icon, .clinic-text').forEach(function (element) {
        element.classList.add('d-none');
    })

    updateDropdown('provinceDropdown', filteredProvincias);
    updateDropdown('provinceLocationDropdown', []);

}

function provinceHandler(provinceLocations, value) {

    var button = document.getElementById('submitter');
    button.classList.add('d-none');


    var valueNumber = parseInt(value);

    var filteredProvinceLocations = provinceLocations.filter(function (provinceLocation) {
        return provinceLocation.provinceId === valueNumber;
    });

    if (filteredProvinceLocations.length == 0) {
        Swal.fire({
            icon: "error",
            title: "Ups...",
            text: "No hay clinicas disponibles en la provincia solicitada! Por favor, elija otra provincia",
        });
    }

    updateDropdown('provinceLocationDropdown', filteredProvinceLocations);
  

}


function updateDropdown(dropdownId, data) {

    var dropdown = document.getElementById(dropdownId);
    dropdown.innerHTML = '';

    var defaultOption = document.createElement('option');
    defaultOption.value = 0;
    defaultOption.text = '--- Seleccione una opcion ---';
    dropdown.add(defaultOption);

    data.forEach(function (element) {
        var option = document.createElement('option');

        option.value = element.id;
        option.text = element.name;

        dropdown.add(option);

    })

}

function provinceLocationDropdownHandler(clinicLocations, value) {

    var submitButton = document.getElementById('submitter');
    submitButton.classList.add('d-none');

    var valueInt = parseInt(value);

    var filteredClinics = clinicLocations.filter(function (clinic) {
        return clinic.provinceLocationId === valueInt;
    })

    if (filteredClinics.length == 0) {
        Swal.fire({
            icon: "error",
            title: "Ups...",
            text: "No hay clinicas disponibles en la localidad solicitada! Por favor, elija otra localidad",
        });
    }
    else {
        Swal.fire({
            icon: "info",
            title: "Clinicas disponibles",
            text: "Por favor, seleccione una clinica a continuacion!",
        });
    }

    var container = document.getElementById('clinicContainer');

    container.innerHTML = '';


    var htmlString = '';

    //Creates an HTML element for each location
    filteredClinics.forEach((location) => {
        htmlString += '<div class="col-4 my-2 d-flex flex-column align-items-center">';
        htmlString += '<i id="' + location.id + '" class="clinic-icon bi bi-flower1 d-flex"></i>';
        htmlString += '<p class="clinic-text">' + location.title + '</p>';
        htmlString += '</div>';
    });

    container.innerHTML = htmlString;

    document.querySelectorAll('.clinic-icon').forEach(function (icon) {

        icon.classList.add('nonselected-clinic')

        icon.addEventListener('click', function() {

            document.querySelectorAll('.clinic-icon').forEach(function (icon) {
                icon.classList.remove('selected-clinic');
                icon.classList.add('nonselected-clinic');
            })

            this.classList.remove('nonselected-clinic');
            this.classList.add('selected-clinic');

            var hiddenForIndex = document.getElementById('SelectedLocationIndex');
            hiddenForIndex.value = this.id;

            var submitButton = document.getElementById('submitter');
            submitButton.classList.remove('d-none');

        });


    })

}
