$(function () {
    //Check what site the tablet is assigned to and grab the id;

    //Set the tablet branding per site

    //Load employees
    $.ajax({
        method: 'GET',
        url: 'api/employees',
        success: function (employee) {
            employee.forEach(function (employee) {
                $('#persons').append('<div class="personCard d-flex" data-id=' + employee.id + '><div class="col d-flex justify-content-center align-items-center flex-column"><p><strong>' + employee.firstName + '</strong></p><p>' + employee.surname + '</p></div><div class="col" id="picture"><img src="/images/Portrait_Placeholder.png"></div></div>')
            });
            registerOnClick();
        }
    });
});

function registerOnClick() {
    $('.personCard').on('click', personClicked);
}

function personClicked() {
    var person = this;
    person.style.backgroundColor = "#ededed";
    setTimeout(function () {
        person.style.backgroundColor = "";
    }, 250);

    $.ajax({
        method: 'GET',
        url: 'api/employees/' + $(person).attr('data-id'),
        success: function (employee) {
            $('#modalBody').attr('data-id', employee.id);
            $('#modal').modal('toggle');
        }
    });
}