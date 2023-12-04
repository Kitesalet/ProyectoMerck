

async function GetMap() {

    map = new Microsoft.Maps.Map(document.getElementById('mapper'), {
        credentials: 'Ans7MhY4N2wow6lyrbE9gL7eXhZJAjTIp76MkysYSWln1kmnzP43uDzPT_jd7yHu',
        center: new Microsoft.Maps.Location(-34.600677504040895, -58.387263729958455)
    });

    //Array of locations

    var fertLocations = [
        { latitude: -34.600677504040895, longitude: - 58.387263729958455, title: 'CEGYR', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.58070285263448, longitude: - 58.43026097362766,title: 'CER', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.578846588221204, longitude: - 58.46010393197798, title: 'CIMER', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.59925473372724, longitude: - 58.40181033949003, title: 'CRECER', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.59743905645921, longitude: - 58.39718927947347, title: 'HIALITUS', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.6062022234174, longitude: - 58.425645264604945, title: 'Hospital Italiano', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.596689236707874, longitude: - 58.39973481534347, title: 'IFER', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' },
        { latitude: -34.55712898207461, longitude: - 58.44761812883586, title: 'WEFIV', subTitle: 'Centro Fertilidad', text: 'Brindamos un servicio integral para cada etapa reproductiva. 35 años de experiencia cumpliendo sueños' }
    ]

    for (var i = 0; i < fertLocations.length; i++) {

        var location = new Microsoft.Maps.Location(fertLocations[i].latitude, fertLocations[i].longitude);

        var pin = new Microsoft.Maps.Pushpin(location,
            {
                title: fertLocations[i].title,
                subTitle: fertLocations[i].subTitle,
                text: i
            });

        
        map.entities.push(pin);
    }

    var center = map.getCenter();



}

document.addEventListener('DOMContentLoaded', async () => {
    const map = await GetMap()
});
