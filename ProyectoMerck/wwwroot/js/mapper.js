

async function GetMap() {

    map = new Microsoft.Maps.Map(document.getElementById('mapper'), {
        credentials: 'Ans7MhY4N2wow6lyrbE9gL7eXhZJAjTIp76MkysYSWln1kmnzP43uDzPT_jd7yHu'
    });
}

document.addEventListener('DOMContentLoaded', async () => {
    const map = await GetMap()
});
