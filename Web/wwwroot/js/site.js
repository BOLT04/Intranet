function ajax(o) {
    var xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
        var data = this.response;
        if (xmlhttp.readyState === XMLHttpRequest.DONE) {
            if (xmlhttp.status === 200 || xmlhttp.status === 204) {
                o.onSuccess(data);
            } else {
                o.onError(data);
            }
        }
    };

    xmlhttp.open(o.method, (window.location.origin + "/" + o.url), true);

    if (o.method === 'POST' || o.method === 'PATCH' || o.method === 'PUT') xmlhttp.setRequestHeader('Content-type', 'application/json');

    xmlhttp.send(JSON.stringify(o.data));
}

onError = function (data) {
    alert(data);
}

function getSite(id) {
    ajax({
        method: 'GET',
        url: 'api/sites/' + id,
        onSuccess: function (data) {
            return data.id;
        },
        onError: onError
    });
}

function setBranding(name,  colour) {
    document.getElementsByClassName('navbar-brand').item(0).innerHTML = name;
    document.body.setAttribute('style', 'background-color: ' + colour + ';');
}

function sendScreenCode() {
    var code = document.getElementById('code').value;
    ajax({
        method: 'POST',
        data: { code: code },
        url: 'api/screens/register',
        onSuccess: function(data) {
            alert("Test" + data)
        },
        onError: onError
    });
}

function initScreen() {

}