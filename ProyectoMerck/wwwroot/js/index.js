


  /*  const submitButton = document.getElementById('FertSubmitButton');*/



    //var form = document.getElementById('CalculateFertilityForm');
    //form.addEventListener('submit', (event) => {
    //    event.preventDefault();

    //    AgeSubmitHandler();
    //})




const AgeSubmitHandler = () => {
    var form = document.getElementById('CalculateFertilityForm');

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        var formData = new FormData(form);

        // Creation of JSON object from form data
        var jsonData = {};
        formData.forEach((value, key) => {
            jsonData[key] = value;
        });

        var json = JSON.stringify(jsonData);

        // Post using AJAX


        fetch('Fertility/CalculateFertility', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams(new FormData(this))
        })
            .then(response => {
                if (!response.ok) {
                    return response.json().then(error => Promise.reject(error));
                }
                return response.json();
            })
            .then(data => {
                // Check for a successful response and redirect if needed
                if (data.redirectUrl) {
                    window.location.href = data.redirectUrl;
                } else {
                    // Handle other cases as needed
                }
            })
            .catch(error => {
                // Handle the BadRequest response
                if (error && error.message) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: error.message
                    });
                } else {
                    // Handle other errors
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'An unexpected error occurred.'
                    });
                }
            });
        
    });
};