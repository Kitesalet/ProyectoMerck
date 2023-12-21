function drawChart(ovuleCount) {

    var array = [['Estado', 'Ovulos']]

    for (var x = 450; x >= 0; x--) {
        var label;
        label = '';
        array.push([label, x]);
    }

    var data = google.visualization.arrayToDataTable(array);

    var options = {
        title: 'Tasa de Fertilidad',
        curveType: 'function',
        legend: { position: 'bottom' },
        crosshair: {
            color: '#2EBDCD',
            trigger: 'selection'
        },
        width: '100%'
    };

    var chart = new google.visualization.LineChart(document.getElementById('curveChart'));

    chart.draw(data, options);

    var ovulosReales = -1 * (-450 + ovuleCount);

    chart.setSelection([{
        row: ovulosReales,
        column: 1
    }])

}