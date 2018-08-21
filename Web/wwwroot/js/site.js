$(function () {
    //Check what site the tablet is assigned to and grab the id;

    //Set the tablet branding per site

    //Load employees
    $.ajax({
        method: 'GET',
        url: 'api/employees',
        success: function (data) {
            data.forEach(function (employee) {
                $('#persons').append('<div class="personCard d-flex" data-id=' + employee.id + '><div class="col d-flex justify-content-center align-items-center flex-column"><p><strong>' + employee.firstName + '</strong></p><p>' + employee.surname + '</p></div><div class="col" id="picture"><img src="/images/Portrait_Placeholder.png"></div></div>')
            });
            registerOnClick();
        }
    });
});

function registerOnClick() {
    $('.personCard').click(function () {
        var that = this;
        this.style.backgroundColor = "#ededed";
        $('#modal').modal('toggle');
        setTimeout(function () {
            that.style.backgroundColor = "";
        }, 250)
    });
}