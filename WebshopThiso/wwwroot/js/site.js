// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkTextField(field) {
    document.getElementById("error").innerText =
        (field.value === "") ? "Field is empty." : "Field is filled.";
}