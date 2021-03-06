﻿$(function () {
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
            registerClicked();
        }
    });

    $.ajax({
        method: 'GET',
        url: 'api/employees',
        success: function (employees) {
            employees.forEach(function (employee) {
                $('#employeesTable').append('<tr><td>' + employee.firstName + '</td><td>' + employee.surname + '</td><td></td><td><button type="button" class="btn btn-primary">Edit</button><button type="button" class="btn btn-danger">Delete</button></td></tr>');
            });
        }
    });

    $.ajax({
        method: 'GET',
        url: 'api/sites',
        success: function (sites) {
            sites.forEach(function (site) {
                $('#sitesTable').append('<tr><td>' + site.name + '</td><td>' + site.colour + '</td><td><button type="button" class="btn btn-primary">Edit</button><button type="button" class="btn btn-danger">Delete</button></td></tr>');
            });
        }
    });
});

function registerClicked() {
    $('.personCard').on('click', personClicked);
    $('#addEmployee').on('click', addEmployee);
    $('#addSite').on('click', addSite);
    $('#modal').on('hidden.bs.modal', resetModal)
}

function personClicked() {
    var person = this;
    var personId = $(person).attr('data-id');
    person.style.backgroundColor = "#ededed";
    setTimeout(function () {
        person.style.backgroundColor = "";
    }, 250);

    $.ajax({
        method: 'GET',
        url: 'api/employees/' + personId,
        success: function (data) {
            var personFullName = data.fullName;
            $.ajax({
                method: 'GET',
                url: 'api/signins/',
                data: {
                    EmployeeId: personId
                },
                success: function (data) {
                    var signin;
                    var date;

                    if (data.length != 0) {
                        signin = data[0];
                        date = new Date(signin.timeIn);
                    }

                    if (date == null || date.getDate < new Date().getDate || signin.timeOut != null) {
                        $('#modalBody').html('<div id="signIn" class="col d-flex justify-content-center flex-column text-center py-5"><h3>Sign In</h3></div>');
                        $('#signIn').on('click', personSignIn);
                    } else {
                        $('#modalBody').html('<div id="signOut" class="col d-flex justify-content-center flex-column text-center py-5"><h3>Sign Out</h3></div>');
                        $('#signOut').attr('data-id', signin.id)
                        $('#signOut').on('click', personSignOut);
                    }

                    $('#modalBody').attr('data-id', personId);
                    $('#modalLongTitle').html('Confirmation: ' + personFullName);
                    $('#modal').modal('toggle');
                }
            });
        }
    });
}

function personSignIn() {
    personId = $('#modalBody').attr('data-id');
    $.ajax({
        method: 'POST',
        url: 'api/signins/',
        data: JSON.stringify({
            EmployeeId: parseInt(personId),
            SiteId: 5
        }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            $('#modal').modal('toggle');
        }
    });
}

function personSignOut() {
    personId = $('#modalBody').attr('data-id');
    signinId = $('#signOut').attr('data-id');

    $.ajax({
        method: 'GET',
        url: 'api/signins/' + signinId,
        success: function (data) {
            var date = new Date(data.timeIn);
            if (date.getDate < new Date().getDate) {
                console.log("This shouldn't of happened! Date of signin is less than today.")
            } else {
                $.ajax({
                    method: 'PUT',
                    url: 'api/signins/' + data.id,
                    data: JSON.stringify({
                        SigninId: data.id,
                        EmployeeId: data.employeeId,
                        SiteId: data.siteId,
                        TimeIn: data.timeIn,
                        TimeOut: new Date(Date.now())
                    }),
                    dataType: 'json',
                    contentType: 'application/json',
                    success: function (data) {
                        $('#modal').modal('toggle');
                    }
                })
            }
        }
    });
}

function resetModal() {
    $('#modal-title').html(null);
    $('#modalBody').html(null);
}

function addEmployee() {
    $('#modal-title').html("Add Employee");
    $('#modalBody').html($('#employeeTemplate').clone().contents());
    $('#modal').modal('toggle');
}

function editEmployee() {
    // Get Employee data
    $('#modal-title').html("Edit Employee");
    $('#modalBody').html($('#employeeTemplate').clone().contents());
}

function addSite() {
    $('#modal-title').html("Add Site");
    $('#modalBody').html($('#siteTemplate').clone().contents());
    $('#modal').modal('toggle');
}

function editSite() {
    // Get Site data
    $('#modal-title').html("Edit Site");
    $('#modalBody').html($('#siteTemplate').clone().contents());
}

function saveEmployee() {

}

function saveSite() {

}