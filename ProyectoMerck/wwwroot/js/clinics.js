var arrowContainer = document.getElementById('arrowContainer');
var rightArrow = document.getElementById('arrowRight');
var leftArrow = document.getElementById('arrowLeft');
var container = document.getElementById('clinicContainer');


var currentPage = parseInt(localStorage.getItem('currentPage')) || null;
var itemsPerPage = parseInt(localStorage.getItem('itemsPerPage')) || null;
var totalItems = parseInt(localStorage.getItem('totalItems')) || null;
var maxPage = parseInt(localStorage.getItem('maxPage')) || null;
var filteredProvincias = JSON.parse(localStorage.getItem('filteredProvincias')) || null;
var filteredProvinceLocations = JSON.parse(localStorage.getItem('filteredProvinceLocations')) || null;
var filteredClinics = JSON.parse(localStorage.getItem('filteredClinics')) || null;
var provinceValue = parseInt(localStorage.getItem('provinceValue')) || null;
var locationValue = parseInt(localStorage.getItem('locationValue')) || null;
var selectedIconId = parseInt(localStorage.getItem('selectedIconId')) || null;
document.getElementById('countryDropdown').addEventListener('change', function () {


    countryHandler(provinceList, this.value);

});

document.getElementById('provinceDropdown').addEventListener('change', function () {
    provinceHandler(locationList, this.value);

    localStorage.setItem('provinceValue', this.value);

})

document.getElementById('provinceLocationDropdown').addEventListener('change', function () {

    localStorage.setItem('locationValue', this.value);

    provinceLocationDropdownHandler(clinicLocationList, this.value);
})

rightArrow.addEventListener('click', function () {

    localStorage.removeItem('selectedIconId');
    selectedIconId = null;

    if (currentPage < maxPage) {


        currentPage++;
        localStorage.setItem('currentPage', currentPage);

        paginate(currentPage, container, itemsPerPage);

    } else {

        Swal.fire({
            icon: "error",
            title: "Ups...",
            text: "Usted se encuentra en la ultima pagina!",
        });

    }
})

leftArrow.addEventListener('click', function () {

    localStorage.removeItem('selectedIconId');
    selectedIconId = null;

    if (currentPage > 1) {

        currentPage--;
        localStorage.setItem('currentPage', currentPage);

        paginate(currentPage, container, itemsPerPage);

    } else {
        Swal.fire({
            icon: "error",
            title: "Ups...",
            text: "Usted se encuentra en la primera pagina",
        });
    }
})

function countryHandler(provincias, value) {

    localStorage.removeItem('selectedIconId');
    selectedIconId = null;

    var submitButton = document.getElementById('submitter');
        submitButton.classList.add('d-none');

    arrowContainer.classList.add('d-none');

    container = document.getElementById('clinicContainer');

    container.classList.add('clinic-container');
    container.classList.remove('clinic-container-error');

    var selectedCountry = parseInt(value);

    var allProvincias = provincias;

    filteredProvincias = allProvincias.filter(function (provincia) {
        return provincia.countryId === selectedCountry;
    })

    localStorage.setItem('filteredProvincias', JSON.stringify(filteredProvincias));

        if (filteredProvincias.length == 0) {
            Swal.fire({
                icon: "error",
                title: "Ups...",
                text: "No hay clinicas disponibles en el pais seleccionado! Por favor, elija otro pais",
            });

            container.innerHTML = '<h2 class="text-center text-light align-self-center">Por favor, seleccione otro Pais</h2>'

        }
        else {
            container.innerHTML = '<h2 class="text-center text-light align-self-center">Por favor, seleccione una Provincia</h2>'
        }


    document.querySelectorAll('.clinic-icon, .clinic-text').forEach(function (element) {
        element.classList.add('d-none');
    })

    updateDropdown('provinceDropdown', filteredProvincias);
    updateDropdown('provinceLocationDropdown', []);

}

function provinceHandler(provinceLocations, value) {

    localStorage.removeItem('selectedIconId');
    selectedIconId = null;

    var button = document.getElementById('submitter');
    button.classList.add('d-none');

    arrowContainer.classList.add('d-none');

    container = document.getElementById('clinicContainer');
    container.classList.add('clinic-container');
    container.classList.remove('clinic-container-error');

    var valueNumber = parseInt(value);

    filteredProvinceLocations = provinceLocations.filter(function (provinceLocation) {
        return provinceLocation.provinceId === valueNumber;
    });

    localStorage.setItem('filteredProvinceLocations', JSON.stringify(filteredProvinceLocations));

    if (filteredProvinceLocations.length == 0) {
        Swal.fire({
            icon: "error",
            title: "Ups...",
            text: "No hay clinicas disponibles en la provincia solicitada! Por favor, elija otra provincia",
        });

        container.innerHTML = '<h2 class="text-center text-light align-self-center">Por favor, seleccione una Provincia</h2>'

    }
    else {

        container.innerHTML = '<h2 class="text-center text-light align-self-center">Por favor, seleccione una localidad</h2>'


    }

    updateDropdown('provinceLocationDropdown', filteredProvinceLocations);
  

}
function provinceLocationDropdownHandler(clinicLocations, value) {

    localStorage.removeItem('selectedIconId');
    selectedIconId = null;

    var submitButton = document.getElementById('submitter');
    submitButton.classList.add('d-none');

    arrowContainer.classList.remove('d-none');

    container = document.getElementById('clinicContainer');
    container.classList.remove('clinic-container-error');
    container.classList.add('clinic-container');

    var valueInt = parseInt(value);

    filteredClinics = clinicLocations.filter(function (clinic) {
        return clinic.provinceLocationId === valueInt;
    })

    localStorage.setItem('filteredClinics', JSON.stringify(filteredClinics));

    if (filteredClinics.length == 0) {
        Swal.fire({
            icon: "error",
            title: "Ups...",
            text: "No hay clinicas disponibles en la localidad solicitada! Por favor, elija otra localidad",
        });

        container.innerHTML = '<h2 class="text-center text-light align-self-center">Por favor, seleccione otra localidad</h2>'

    }
    else {

        Swal.fire({
            icon: "info",
            title: "Clinicas disponibles",
            text: "Por favor, seleccione una clinica a continuacion!",
        });

        currentPage = 1;
        itemsPerPage = 2;
        totalItems = filteredClinics.length;
        maxPage = Math.ceil(totalItems / itemsPerPage);

        localStorage.setItem('currentPage', currentPage);
        localStorage.setItem('itemsPerPage', itemsPerPage);
        localStorage.setItem('totalItems', totalItems);
        localStorage.setItem('maxPage', maxPage);


        container.classList.remove('clinic-container');

        //Renders everything for a first time
        paginate(currentPage,container,itemsPerPage);
        
        
       
    }


    

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
function renderClinics(startIndex, endIndex, container) {
    var htmlString = '';

    for (var i = startIndex; i < endIndex; i++) {

        var location = filteredClinics[i];

        console.log(location);

        if (location !== undefined) {
            htmlString += '<div class="col-4 my-2 d-flex flex-column align-items-center">';
            htmlString += '<i id="' + location.id + '" class="clinic-icon bi bi-flower1 d-flex"></i>';
            htmlString += '<p class="clinic-text">' + location.title + '</p>';
            htmlString += '</div>';
        }

    }
    container.innerHTML = htmlString;
}
function paginate(page, container, itemsPerPage) {


    var startIndex = (page - 1) * itemsPerPage;
    var endIndex = startIndex + itemsPerPage;

    renderClinics(startIndex, endIndex, container);
    updatePagination();
}

function updatePagination() {

    var submitButton = document.getElementById('submitter');
    submitButton.classList.add('d-none');
    document.querySelectorAll('.clinic-icon').forEach(function (icon) {



        icon.classList.add('nonselected-clinic');

        console.log(selectedIconId);

        if (selectedIconId !== null) {
            var selectedIcon = document.querySelector('.clinic-icon[id="'+ selectedIconId +'"]');

            selectedIcon.classList.remove('nonselected-clinic');
            selectedIcon.classList.add('selected-clinic');
            var submitButton = document.getElementById('submitter');
            submitButton.classList.remove('d-none');
        }

        icon.addEventListener('click', function () {

            document.querySelectorAll('.clinic-icon').forEach(function (icon) {
                icon.classList.remove('selected-clinic');
                icon.classList.add('nonselected-clinic');
            })

            this.classList.remove('nonselected-clinic');
            this.classList.add('selected-clinic');

            var hiddenForIndex = document.getElementById('SelectedLocationIndex');
            hiddenForIndex.value = this.id;
            localStorage.setItem('selectedIconId',this.id);

            var submitButton = document.getElementById('submitter');
            submitButton.classList.remove('d-none');

        });


    });

}

window.onload = function () {

    if (errorHappened == true) {

        container.classList.remove('clinic-container');
        container.classList.remove('clinic-container-error');
        arrowContainer.classList.remove('d-none');

        updateDropdown('provinceDropdown', filteredProvincias);
        updateDropdown('provinceLocationDropdown', filteredProvinceLocations);

        var provinceDropdown = document.getElementById('provinceDropdown');
        var provinceLocationDropdown = document.getElementById('provinceLocationDropdown');

        provinceDropdown.value = provinceValue;
        provinceLocationDropdown.value = locationValue;

        paginate(currentPage, container, itemsPerPage);


    } else {
        console.log("Nard")
    }

}



