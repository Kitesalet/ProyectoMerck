// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    var map = null;
    function GetMap() {
        map = new Microsoft.Maps.Map(document.getElementById('mapper'), {
            credentials: 'Ans7MhY4N2wow6lyrbE9gL7eXhZJAjTIp76MkysYSWln1kmnzP43uDzPT_jd7yHu'
        });
    }

    GetMap();



document.addEventListener('DOMContentLoaded', GetMap)