

async function GetMap(locations) {
    var map = new Microsoft.Maps.Map(document.getElementById('mapper'), {
        credentials: 'Ans7MhY4N2wow6lyrbE9gL7eXhZJAjTIp76MkysYSWln1kmnzP43uDzPT_jd7yHu',
        center: new Microsoft.Maps.Location(-34.600677504040895, -58.387263729958455)
    });

    //Array of locations
    var fertLocations = JSON.parse(locations);

    for (var i = 0; i < fertLocations.length; i++) {
        var location = new Microsoft.Maps.Location(fertLocations[i].Latitude, fertLocations[i].Longitude);

        var pin = new Microsoft.Maps.Pushpin(location, {
            title: fertLocations[i].Title,
            subTitle: fertLocations[i].Subtitle, 
            icon: 'https://gcdnb.pbrd.co/images/QZBmUGUTPzhr.png',
            size: new Microsoft.Maps.Point(30, 30),
            anchor: new Microsoft.Maps.Point(12, 39)
        });

        map.entities.push(pin);
    }

}

