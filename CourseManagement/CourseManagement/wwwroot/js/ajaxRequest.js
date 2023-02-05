document.addEventListener("DOMContentLoaded", function () {
    let errors = tempData;
    if (errors)
        openModal(errors);
});

function courseManagement(event) {
    let operation;
    let btn = event.id;
    let courseIndex = btn.substring(btn.indexOf("_") + 1);

    switch (true) {
        case btn.includes("reg"):
            operation = "Register";
            break;
        case btn.includes("unr"):
            operation = "Unregister";
            break;
        case btn.includes("edt"):
            operation = "Edit";
            break;
        default:
            operation = "Delete";
            break;
    }

    $.ajax({
        method: "POST",
        url: "/Course/Courses",
        data: {
            CourseId: courseIndex,
            Operation: operation,
        },
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function () {
            window.location.href = window.location.href;
        },
        error: function () {
        }
    });
}

function openModal(message) {
    let errorContent = document.getElementById("errorBody");
    errorContent.innerHTML = message;
    $("#errorModal").modal("show");
}

function editCourse(event) {
    let btn = event.id;
    let courseIndex = btn.substring(btn.indexOf("_") + 1);
    document.getElementById('courseId').value = courseIndex;
    $("#editModal").modal("show");
}

function closeModal() {
    $("#editModal").modal('hide');
}

function redirectToCourse() {
    window.location.href = '/Course/Courses';
}


