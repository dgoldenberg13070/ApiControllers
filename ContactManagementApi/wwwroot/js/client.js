$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/contact",
            contentType: "application/json",
            method: "POST",
            data: JSON.stringify({
                firstName: this.elements["FirstName"].value,
                lastName: this.elements["LastName"].value,
                company: this.elements["Company"].value,
                profileImage: this.elements["ProfileImage"].value,
                email: this.elements["Email"].value,
                birthDate: this.elements["BirthDate"].value,
                workPhone: this.elements["WorkPhone"].value,
                personalPhone: this.elements["PersonalPhone"].value,
                city: this.elements["City"].value,
                state: this.elements["State"].value,
                zip: this.elements["Zip"].value
            }),
            success: function (data) {
                addTableRow(data);
            }
        })
    });
});

var addTableRow = function (contact) {
    $("table tbody").append("<tr><td>" + contact.contactId + "</td><td>"
        + contact.firstName + "</td><td>"
        + contact.lastName + "</td><td>"
        + contact.company + "</td><td>"
        + contact.profileImage + "</td><td>"
        + contact.email + "</td><td>"
        + contact.birthDate + "</td><td>"
        + contact.workPhone + "</td><td>"
        + contact.personalPhone + "</td><td>"
        + contact.city + "</td><td>"
        + contact.state + "</td><td>"
        + contact.zip + "</td></tr>"
    );
}
